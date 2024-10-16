const readline = require('readline');

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

async function sendPrompt(prompt) {
    const requestData = {
        model: "phi3:latest", //  model name , check by ollama List 
        prompt: prompt
    };

    try {
        const response = await fetch("http://localhost:8080/api/generate", { // macth port to port running ollama
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(requestData)
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        // Process the response as a stream of text lines
        const reader = response.body.getReader();
        const decoder = new TextDecoder();
        let done = false;
        let buffer = "";
        let fullResponse = "Ollama: ";

        while (!done) {
            const { value, done: streamDone } = await reader.read();
            buffer += decoder.decode(value || new Uint8Array(), { stream: true });

            // Split the buffer into complete JSON objects (separated by newlines)
            let parts = buffer.split("\n");

            // The last part could be an incomplete JSON object, so save it for the next iteration
            buffer = parts.pop();

            for (const part of parts) {
                if (part.trim()) {
                    try {
                        const parsed = JSON.parse(part);
                        // Collect the response text and add to the full response string
                        fullResponse += parsed.response;
                    } catch (error) {
                        console.error("Failed to parse JSON part:", part, error);
                    }
                }
            }

            done = streamDone;
        }

        // If there's leftover in the buffer, try to parse it
        if (buffer.trim()) {
            try {
                const parsed = JSON.parse(buffer);
                //fullResponse += parsed.response;
                console.log(parsed.response)
            } catch (error) {
                console.error("Failed to parse final JSON part:", buffer, error);
            }
        }

        // Print the full response
        //console.log(fullResponse);

    } catch (error) {
        console.error("Error:", error);
    }
}

// Function to prompt user input and send it
function promptUser() { //all
    rl.question('me: ', async (input) => {
        await sendPrompt(input);
        promptUser(); 
    });
}

// Start the input loop
promptUser();
