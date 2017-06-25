+==============================================================================+
| IDENTIFICAÇÃO DOS ELEMENTOS DO GRUPO                                         |
+==============================================================================+

Carlos Manuel Carvalho Boavista Samouco
up201305187@fe.up.pt

Diogo Belarmino Coelho Marques
up201305642@fe.up.pt

José Alexandre Barreira Santos Teixeira
up201303930@fe.up.pt

+==============================================================================+
| INSTRUÇÕES DE EXECUÇÂO (APLICAÇÃO WEB)                                       |
+==============================================================================+

Pré-requisitos: NodeJS, npm (https://nodejs.org/en/)

cd libretto-online
npm install
npm install --global gulp
gulp serve

+==============================================================================+
| INSTRUÇÕES DE EXECUÇÂO (APLICAÇÕES .NET)                                     |
+==============================================================================+

(Executar)

Instalar certificado pessoal FeupEnterprise.pfx nos certificados do sistema.

Na pasta "Assembly" encontram-se os executáveis do projeto, separados em duas
pastas: "Client" para a aplicação cliente do armazém (WarehouseClient.exe),
loja (LibrettoClient.exe), e faturação (LibrettoInvoice.exe); "Server" para as
aplicaçoes servidor do armazém (WarehouseServer.exe) e loja (LibrettoServer.ee)

Na pasta do servidor existe ainda uma base de dados SQL Server no formato MDF
já com a informação preenchida (LibrettoDatabase.mdf).

Para testar as aplicações basta executar uma instância de ambos os servidores,
bem como uma ou várias instâncias das três aplicações cliente.

(Compilar)

Abrir ficheiros solution (.sln) no Visual Studio (versão 2015 ou superior).
Se ocorrerem erros na compilação relativos às referências do projeto, instalar
Entity Framework 6.1.3 através do NuGet Package Manager.

(Login [Funcionário])

E-mail: admin@libretto.pt
Password: changemeplease

E-mail: samouco@libretto.pt
Password: dormirebom666

E-mail: alhexan@libretto.pt
Password: m80terino

(Login [Cliente])

E-mail: marques999@gmail.com
Password: 123

E-mail: matt_perry@hotmail.com
Password: 123

E-mail: randy@gmail.com
Password: 123

E-mail: steven.xxx@outlook.com
Password: 123