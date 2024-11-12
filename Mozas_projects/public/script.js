document.getElementById('numDisciplinas').addEventListener('input', function() {
    const numDisciplinas = parseInt(this.value);
    const disciplinasDiv = document.getElementById('disciplinasDiv');
    disciplinasDiv.innerHTML = ''; // Limpa os campos anteriores

    for (let i = 0; i < numDisciplinas; i++) {
        const label = document.createElement('label');
        label.textContent = `Disciplina ${i + 1}:`;

        const input = document.createElement('input');
        input.type = 'text';
        input.id = `disciplina${i + 1}`;
        input.required = true;

        disciplinasDiv.appendChild(label);
        disciplinasDiv.appendChild(input);
        disciplinasDiv.appendChild(document.createElement('br'));
    }
});

document.getElementById('formCadastro').addEventListener('submit', function(event) {
    event.preventDefault(); // Impede o envio do formulário

    const nome = document.getElementById('nome').value;
    const idade = document.getElementById('idade').value;
    const curso = document.getElementById('curso').value;
    const numDisciplinas = document.getElementById('numDisciplinas').value;
    const disciplinas = [];

    // Coleta as disciplinas
    for (let i = 0; i < numDisciplinas; i++) {
        const disciplina = document.getElementById(`disciplina${i + 1}`).value;
        if (!disciplina) {
            alert('Por favor, preencha todas as disciplinas.');
            return;
        }
        disciplinas.push(disciplina);
    }

    // Validação de dados
    if (!nome || !idade || !curso) {
        alert('Por favor, preencha todos os campos.');
        return;
    }

    // Envia os dados para o servidor
    const aluno = {
        nome: nome,
        idade: idade,
        curso: curso,
        disciplinas: disciplinas
    };

    fetch('/cadastrar', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(aluno)
    })
        .then(response => response.json())
        .then(data => {
            document.getElementById('mensagemCadastro').innerHTML = `
            <h3>Cadastro realizado com sucesso!</h3>
            <p>Aluno: ${aluno.nome}</p>
            <p>Curso: ${aluno.curso}</p>
            <p>Disciplinas: ${aluno.disciplinas.join(', ')}</p>
        `;
            window.location.href = '/interacao'; // Redireciona para a página de interação
        })
        .catch(error => {
            alert('Erro ao salvar dados.');
        });
});
