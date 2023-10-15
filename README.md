# Sistema de Gerenciamento de Ordens de Produção

Este é um sistema de gerenciamento de ordens de produção que permite usuários realizarem várias operações de gerenciamento de produção. O sistema para este desafio técnico foi desenvolvido em .NET/C#.
OBS: Minha solução para os dados de saída no desafio, foi gerar dois arquivos em JSON para que assim os dados possam ser utilizados por qualquer outro sistema, independente de linguagem de programação, ficando acessível e disponível.

## Requisitos

- Ambiente de desenvolvimento C# ( SDK e demais requisitos para a tecnologia .NET/C# )
- Conhecimento básico de C#
- Git (opcional, para clonar o repositório)

## Como Usar

1. **Configuração Inicial:**
   - Clone o repositório ou baixe os arquivos do projeto.
   - Abra o projeto em seu ambiente de desenvolvimento C#.

2. **Compilação e Execução:**
   - Compile e execute o código. Isso iniciará o sistema de gerenciamento de ordens de produção no console.
   ```shell
   dotnet run
   ```
   - Ao clonar ou realizar o download do projeto, ele pode ser aberto no vscode por exemplo, bastando apenas abrir um terminal e rodar o comando acima.

3. **Menu de Opções:**
   
   
   ![image](https://github.com/fabiodrneles/desafio-junior-ordem-product/assets/42509240/c9326459-da70-4d1d-80f2-6d090385c0d3)
   

   - O sistema oferecerá um menu com várias opções (1 a 8).
   - Escolha uma opção digitando o número correspondente e pressionando "Enter".
   - Os Arquivos de saída estão nomeados como materials.json e orders.json
   - A opção 7 cadastrar material deve conter o mesmo nome de registro da opção 1 - Registrar uma nova ordem de produção.
   - A data no registro de ordem da opção 1 pode ser opcional, porém se for registrada deve respeitar o formato dd/MM/yyyy
     
     ![image](https://github.com/fabiodrneles/desafio-junior-ordem-product/assets/42509240/c7decb3d-ec30-4537-8440-47392ddb09d7)

     ![image](https://github.com/fabiodrneles/desafio-junior-ordem-product/assets/42509240/4b8f2d63-3721-40ad-859e-911b15c36ceb)

     ![image](https://github.com/fabiodrneles/desafio-junior-ordem-product/assets/42509240/58bdfff9-8de6-4995-b0e8-35448140bdb3)
  
     A opção 3 verifica os materiais disponíveis, estes devem ser buscados com o mesmo nome que foi cadastrado na opção 7, respeitando tanto letras Maiúsculas e minusculas se houver. Aquantidade se cadastrada maior do que a quantidade necessária resulta em uma mensagem positiva para disponibilidade, do contrário se a quantidade de necessidade na busca por disponibilidade for menor do que a quantidade cadastrada na opção 7, a mensagem será negativa para disponibilidade.

     ![image](https://github.com/fabiodrneles/desafio-junior-ordem-product/assets/42509240/d598a5b6-4fe3-4584-9452-8481da67397a)

     ![image](https://github.com/fabiodrneles/desafio-junior-ordem-product/assets/42509240/bd2dd30f-15d8-454a-ab9d-0d1b3207b6b3)

     A opção 4 atualizar o status deve ser respondida exatamente de acordo com a mensagem entre parenteses. O ID que é solicitado aparece na opção 2

     ![image](https://github.com/fabiodrneles/desafio-junior-ordem-product/assets/42509240/8398bf27-96f7-405a-8912-f546fc0dd2f1)

     O ID será solicitado na opção 6 para remover, pode ser encontradona opção 2

     ![image](https://github.com/fabiodrneles/desafio-junior-ordem-product/assets/42509240/7584ae3e-dea1-495a-b553-b9666f6b538e)

     Os arquivos orders.json e o materials estão no formato json e são incrementados a medida que as ordens ou materiais são cadastrados.
     ![image](https://github.com/fabiodrneles/desafio-junior-ordem-product/assets/42509240/bd28d1a6-cfcb-4ea1-864e-d9d84bb05d18)

     ![image](https://github.com/fabiodrneles/desafio-junior-ordem-product/assets/42509240/7a11d083-471e-4731-8753-d49d7a50bf1f)

     Estes arquivos estão com a data e hora no formato ISO 8601 (YYYY-MM-DDTHH:MM:SS), onde "YYYY" representa o ano, "MM" o mês, "DD" o dia, "THH" a hora, "MM" os minutos e "SS" os segundos. Porém a hora foi suprimida a nivel de codigo, caso deseje basta modificar no codigo para que seja fornecida esta informação da hora.


## Exemplos de Uso

Aqui estão alguns exemplos de como usar o sistema:

- **Exemplo 1: Registro de Nova Ordem de Produção**
   - Escolha a opção 1 no menu.
   - Siga as instruções para inserir os detalhes da nova ordem de produção, incluindo o produto, a quantidade e, opcionalmente, a data de entrega.

- **Exemplo 2: Listar Todas as Ordens de Produção**
   - Escolha a opção 2 no menu.
   - O sistema listará todas as ordens de produção existentes, incluindo detalhes como ID, produto, quantidade, data de entrega e status.

- **Exemplo 3: Verificar Materiais Disponíveis**
   - Escolha a opção 3 no menu.
   - Siga as instruções para inserir o nome do produto e a quantidade necessária.
   - O sistema verificará se a produção é possível com base nos materiais disponíveis.

- **Exemplo 4: Atualizar Status de Ordem de Produção**
   - Escolha a opção 4 no menu.
   - Siga as instruções para inserir o ID da ordem de produção que deseja atualizar e o novo status (Em andamento/Concluída).

- **Exemplo 5: Visualizar Relatórios de Produção**
   - Escolha a opção 5 no menu.
   - O sistema mostrará relatórios de produção, incluindo ordens em andamento e concluídas.

- **Exemplo 6: Remover uma Ordem de Produção**
   - Escolha a opção 6 no menu.
   - Siga as instruções para inserir o ID da ordem de produção que deseja remover.
   - O sistema removerá a ordem de produção se o ID for válido.

- **Exemplo 7: Cadastrar um Novo Material**
   - Escolha a opção 7 no menu.
   - Siga as instruções para inserir o nome do material e a quantidade.

- **Exemplo 8: Sair**
   - Escolha a opção 8 para encerrar o sistema.

## Contribuições

Contribuições para este projeto são bem-vindas. Sinta-se à vontade para abrir problemas, enviar solicitações pull e melhorar o sistema.

## Autores

Este sistema foi desenvolvido por Fabio D. Dorneles.

## Prints e imagens guia
em construção...

