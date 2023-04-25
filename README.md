# AgendaPessoal
Uma agenda pessoal feita em .NET7.
O banco de dados roda no SQL Server.
O frontend implementado em VueJs.

Esse foi um desafio feito a mim, com as seguintes caracteristicas:

Requisito de negócio (RN)
Usuário possuir uma agenda pessoal que possa ser acessada, tanto do seu computador quanto do seu tablet e/ou
smartphone.

Requisito de Usuário (RU)
RU #1 – A agenda deverá ser um site
O usuário solicitou um site, pois deseja acessar sua agenda em diversos dispositivos e sem ter a necessidade de
instalar programas. Ele deseja simplicidade, leveza e rapidez.

Requisitos Funcionais (RF)
RF #1 – O usuário poderá consultar e cadastrar quantas pessoas desejar em sua agenda
O usuário espera que esse cadastro contenha o nome completo, 2 telefones para contato, email, data de
nascimento (para fins de solicitações de aniversário) e endereço contendo, na ordem:
• Cep (veja orientações em RNF #4)
• Rua/Avenida
• Número
• Complemento
• Bairro
• Cidade
• Estado
Através de uma lista simples de pesquisa, ele poderá consultar seus contatos. O cliente sugeriu a tela bem simples,
como numa agenda telefônica de smartphone.

RF #2 – O usuário poderá consultar e criar compromissos, como numa agenda pessoal
Nesta funcionalidade, o usuário deseja, de uma forma simples, definir o dia, o horário, o título compromisso e uma
breve descrição do compromisso.

RF #3 – Gerar um backup da agenda de contatos no formato xml
Exportar os contatos da agenda em um arquivo de formato xml, como forma de backup.

Requisitos Não Funcionais (RNF)
RNF #1 – Tecnologia empregada
Para construção da aplicação deve-se utilizar a linguagem C#, pode-se usar o framework ASP.NET Core MVC.
Para o front-end fica a critério a forma que será desenvolvida, não é necessária muita complexidade, pode-se usar
algum framework front-end como por exemplo Bootstrap.

RNF #2 – Banco de Dados empregado
Para banco de dados deve-se utilizar o SQL Server, a arquitetura de construção do banco fica a critério, como
número e nomes de tabelas e campos, porém recomendamos a criação correta de índices e chaves para garantir a
segurança dos dados e que seja bem estruturado a fim de facilitar a compreensão e manutenção da base de dados.

RNF #3- Hospedagem da aplicação
A aplicação pode ser disponibilizada para que possamos executar e testar em local host, caso se sinta confortável
para utilizar algum ambiente de hospedagem fica a critério, mas não é obrigatório.
