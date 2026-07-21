document.addEventListener("DOMContentLoaded", function () {
    const cepInput = document.getElementById("Cep");
    const logradouroInput = document.getElementById("Logradouro");
    const bairroInput = document.getElementById("Bairro");
    const cidadeInput = document.getElementById("Cidade");
    const ufInput = document.getElementById("Uf");

    if (cepInput) {
        cepInput.addEventListener("blur", function () {
            let cep = cepInput.value.replace(/\D/g, '');
            
            if (cep.length === 8) {
                cepInput.classList.remove("is-invalid");
                
                fetch(`https://viacep.com.br/ws/${cep}/json/`)
                    .then(response => response.json())
                    .then(data => {
                        if (!data.erro) {
                            logradouroInput.value = data.logradouro;
                            bairroInput.value = data.bairro;
                            cidadeInput.value = data.localidade;
                            ufInput.value = data.uf;
                            
                            logradouroInput.classList.remove("is-invalid");
                            bairroInput.classList.remove("is-invalid");
                            cidadeInput.classList.remove("is-invalid");
                            ufInput.classList.remove("is-invalid");
                        } else {
                            cepInput.classList.add("is-invalid");
                            alert("CEP não encontrado.");
                        }
                    })
                    .catch(error => {
                        console.error("Erro ao consultar ViaCEP:", error);
                        alert("Erro ao comunicar com o ViaCEP.");
                    });
            } else if (cep.length > 0) {
                cepInput.classList.add("is-invalid");
            }
        });
    }
});
