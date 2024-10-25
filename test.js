const readline = require('readline');
const mammoth = require('mammoth');
const fs = require('fs');

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

// Hardcoded path to the DOCX file
const filePath = "C:\\Users\\edson\\OneDrive\\Desktop\\Novo Documento do Microsoft Word.docx";

async function extractTextFromFile(filePath) {
    try {
        const result = await mammoth.extractRawText({ path: filePath });
        return result.value;
    } catch (error) {
        console.error("Error extracting text from file:", error);
        return null;
    }
}

async function sendPrompt(prompt) {
    const requestData = {
        model: "phi3:latest",
        prompt: prompt
    };

    try {
        const response = await fetch("http://localhost:8080/api/generate", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(requestData)
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const reader = response.body.getReader();
        const decoder = new TextDecoder();
        let done = false;
        let buffer = "";
        let fullResponse = "Ollama: ";

        while (!done) {
            const { value, done: streamDone } = await reader.read();
            buffer += decoder.decode(value || new Uint8Array(), { stream: true });

            let parts = buffer.split("\n");
            buffer = parts.pop();

            for (const part of parts) {
                if (part.trim()) {
                    try {
                        const parsed = JSON.parse(part);
                        fullResponse += parsed.response;
                    } catch (error) {
                        console.error("Failed to parse JSON part:", part, error);
                    }
                }
            }

            done = streamDone;
        }

        if (buffer.trim()) {
            try {
                const parsed = JSON.parse(buffer);
                fullResponse += parsed.response;
            } catch (error) {
                console.error("Failed to parse final JSON part:", buffer, error);
            }
        }

        console.log(fullResponse);

    } catch (error) {
        console.error("Error:", error);
    }
}

async function main() {
    if (fs.existsSync(filePath)) {
        const tosend = await extractTextFromFile(filePath);
        if (tosend) {
            await sendPrompt(tosend); // Send the extracted text
            promptUser(); // Then prompt for user input
        }
    } else {
        console.error("File does not exist. Please check the path.");
    }
}

function promptUser() {
    rl.question('me: ', async (input) => {
        await sendPrompt(input); // Send user input
        promptUser(); // Prompt again
    });
}

// Start the process
main();
