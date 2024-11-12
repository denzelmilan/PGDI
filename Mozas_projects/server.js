const express = require('express');
const fs = require('fs');
const path = require('path');
const bodyParser = require('body-parser');
const axios = require('axios');  // Importar o Axios para fazer as requisições HTTP

const app = express();
const port = 3000;

// Configura o body-parser para processar os dados do formulário
app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.json());  // Necessário para lidar com JSON no corpo da requisição

// Serve arquivos estáticos da pasta 'public'
app.use(express.static(path.join(__dirname, 'public')));

// Rota principal ("/") que serve a página index.html
app.get('/', (req, res) => {
    res.sendFile(path.join(__dirname, 'public', 'index.html'));
});

// Rota para cadastro dos dados
app.post('/cadastrar', (req, res) => {
    const aluno = req.body;
    const alunoData = `Nome: ${aluno.nome}\nIdade: ${aluno.idade}\nCurso: ${aluno.curso}\nDisciplinas: ${aluno.disciplinas.join(', ')}\n\n`;
    const filePath = path.join(__dirname, 'data.txt');

    fs.access(filePath, fs.constants.F_OK, (err) => {
        if (err) {
            fs.writeFile(filePath, alunoData, (writeErr) => {
                if (writeErr) return res.status(500).json({ message: 'Erro ao salvar os dados.' });
                res.status(200).json({ message: 'Cadastro realizado com sucesso!' });
            });
        } else {
            fs.appendFile(filePath, alunoData, (appendErr) => {
                if (appendErr) return res.status(500).json({ message: 'Erro ao salvar os dados.' });
                res.status(200).json({ message: 'Cadastro realizado com sucesso!' });
            });
        }
    });
});


// Rota de interação com IA (usando a API da IA Ollama)
app.post('/interacao', async (req, res) => {
    const { pergunta } = req.body;

    if (!pergunta) {
        return res.status(400).json({ message: 'Por favor, faça uma pergunta.' });
    }

    try {
        // Inicializa a variável para acumular a resposta
        let respostaDaIA = '';
        let done = false;

        // Enquanto a IA não completar a resposta
        while (!done) {
            const response = await axios.post('http://localhost:11434/api/chat', {
                model: "llama3.2",  // O modelo da IA que você está usando
                messages: [
                    { role: "user", content: pergunta }  // A pergunta enviada pelo usuário
                ]
            });

            // Log para verificar cada parte da resposta
            console.log('Resposta fragmentada da IA:', response.data);

            // Acumula a resposta da IA
            if (response.data && response.data.message && response.data.message.content) {
                respostaDaIA += response.data.message.content;  // Adiciona a parte da resposta
                done = response.data.done;  // Se 'done' for true, significa que a resposta completa foi enviada
            }

            // Caso não tenha conteúdo esperado, gera um erro
            if (!response.data || !response.data.message || !response.data.message.content) {
                return res.status(500).json({ message: 'Resposta da IA não está no formato esperado.' });
            }
        }

        // Verifica se a resposta está vazia ou incompleta
        if (!respostaDaIA) {
            return res.status(500).json({ message: 'Não foi possível obter a resposta completa da IA.' });
        }

        // Envia a resposta final ao frontend
        res.json({ resposta: respostaDaIA });
        console.log('Resposta completa da IA:', respostaDaIA);  // Log da resposta completa

    } catch (error) {
        console.error('Erro ao interagir com a IA Ollama:', error);
        res.status(500).json({ message: 'Erro ao interagir com a IA Ollama.' });
    }
});





// Inicializa o servidor
app.listen(port, () => {
    console.log(`Servidor rodando em http://localhost:${port}`);
});
