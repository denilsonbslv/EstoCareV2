# EstoCare

Este projeto visa criar uma aplicação de gerenciamento de estoque para uma loja de peças de moto. A ideia é permitir que o proprietário da loja tenha acesso aos itens do estoque e possa gerenciar as vendas e o controle de inventário de maneira eficiente.

## Tecnologias Utilizadas

- **.NET 8**: Framework principal para o desenvolvimento da API.
- **Entity Framework Core**: Para a gestão de banco de dados e migrações.
- **SQL Server**: Banco de dados utilizado para armazenar informações de estoque.
- **Git**: Controle de versão.

## Como configurar o ambiente

### 1. Instalar o SQL Server LocalDB

Para configurar o banco de dados local, baixe e instale o **SQL Server Express**, que inclui o **LocalDB**.

- Acesse o link abaixo para baixar o instalador do **SQL Server Express**:
  [Download do SQL Server Express](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

- Execute o arquivo `SqlLocalDB.msi` e siga as instruções para concluir a instalação.

### 2. Clonar o repositório

Após a instalação do LocalDB, clone este repositório para o seu computador com o seguinte comando:

```bash
git clone https://github.com/denilsonbslv/EstoCareV2
