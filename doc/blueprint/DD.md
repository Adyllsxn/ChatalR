# DICIONÁRIO DE DADOS

---

## TABELA => USUÁRIO

| Campo        | Descrição                               | Tipo de Dados | Tamanho | Obrigatório | Chave Primária | Chave Estrangeira | Observações                         |
|--------------|-----------------------------------------|---------------|---------|-------------|----------------|-------------------|-----------------------------------|
| id           | Identificador único do usuário          | INT           | -       | Sim         | Sim            | Não               | Auto incremento                    |
| nome         | Nome completo do usuário                 | NVARCHAR      | 100     | Sim         | Não            | Não               |                                   |
| email        | Email do usuário                         | NVARCHAR      | 100     | Sim         | Não            | Não               | Deve ser único                    |
| senhaHash    | Senha armazenada em formato criptografado| NVARCHAR    | 255     | Sim         | Não            | Não               |                                   |
| perfilId     | Identificador do perfil do usuário      | INT           | -       | Sim         | Não            | Sim               | FK para tabela PERFIL             |
| ativo        | Indica se o usuário está ativo           | BIT           | -       | Sim         | Não            | Não               | Valores: 1 (ativo), 0 (inativo)  |
| dataCadastro | Data e hora do cadastro do usuário       | DATETIME      | -       | Sim         | Não            | Não               |                                   |

---

## TABELA => PERFIL

| Campo | Descrição                    | Tipo de Dados | Tamanho | Obrigatório | Chave Primária | Chave Estrangeira | Observações                      |
|-------|------------------------------|---------------|---------|-------------|----------------|-------------------|--------------------------------|
| id    | Identificador único do perfil | INT           | -       | Sim         | Sim            | Não               | Auto incremento                 |
| nome  | Nome do perfil               | NVARCHAR      | 50      | Sim         | Não            | Não               | Ex: Administrador, Organizador, Membro |

---

## TABELA => TIPO DE EVENTOS

| Campo | Descrição                     | Tipo de Dados | Tamanho | Obrigatório | Chave Primária | Chave Estrangeira | Observações                   |
|-------|-------------------------------|---------------|---------|-------------|----------------|-------------------|-----------------------------|
| id    | Identificador único do tipo de evento | INT    | -       | Sim         | Sim            | Não               | Auto incremento              |
| nome  | Nome do tipo de evento         | NVARCHAR      | 50      | Sim         | Não            | Não               | Ex: Culto, Vigília, Encontro de Jovens |

---

## TABELA => EVENTOS

| Campo           | Descrição                                    | Tipo de Dados | Tamanho | Obrigatório | Chave Primária | Chave Estrangeira | Observações                                                        |
|-----------------|----------------------------------------------|---------------|---------|-------------|----------------|-------------------|------------------------------------------------------------------|
| id              | Identificador único do evento                 | INT           | -       | Sim         | Sim            | Não               | Auto incremento                                                  |
| titulo          | Título do evento                              | NVARCHAR      | 100     | Sim         | Não            | Não               |                                                                  |
| descricao       | Descrição detalhada do evento                  | NVARCHAR(MAX) | -       | Sim         | Não            | Não               |                                                                  |
| dataHoraInicio  | Data e hora de início do evento                | DATETIME      | -       | Sim         | Não            | Não               |                                                                  |
| dataHoraFim     | Data e hora de término do evento               | DATETIME      | -       | Sim         | Não            | Não               |                                                                  |
| local           | Local onde o evento será realizado             | NVARCHAR      | 100     | Sim         | Não            | Não               |                                                                  |
| tipoEventoId    | Identificador do tipo de evento                | INT           | -       | Sim         | Não            | Sim               | FK para tabela TIPO DE EVENTOS                                   |
| usuarioId       | Identificador do usuário que criou/organizou o evento | INT    | -       | Sim         | Não            | Sim               | FK para tabela USUÁRIO                                           |
| statusAprovacao | Status da aprovação do evento                   | NVARCHAR      | 20      | Sim         | Não            | Não               | Valores possíveis: 'Pendente', 'Aprovado', 'Rejeitado'          |
| imagemUrl       | URL da imagem relacionada ao evento (opcional) | NVARCHAR(MAX) | -       | Não         | Não            | Não               | Pode ser arte, panfleto, etc.                                   |

---

## TABELA => PRESENÇA

| Campo           | Descrição                                    | Tipo de Dados | Tamanho | Obrigatório | Chave Primária | Chave Estrangeira | Observações                   |
|-----------------|----------------------------------------------|---------------|---------|-------------|----------------|-------------------|-----------------------------|
| id              | Identificador único da presença               | INT           | -       | Sim         | Sim            | Não               | Auto incremento              |
| usuarioId       | Identificador do usuário                      | INT           | -       | Sim         | Não            | Sim               | FK para tabela USUÁRIO       |
| eventoId        | Identificador do evento                        | INT           | -       | Sim         | Não            | Sim               | FK para tabela EVENTOS       |
| dataHoraCheckin | Data e hora do check-in                        | DATETIME      | -       | Sim         | Não            | Não               |                             |
| dataHoraCheckout| Data e hora do check-out (futuro opcional)    | DATETIME      | -       | Não         | Não            | Não               |                             |

---

## TABELA => SUGESTÃO PRIVADA

| Campo      | Descrição                                   | Tipo de Dados | Tamanho | Obrigatório | Chave Primária | Chave Estrangeira | Observações                                             |
|------------|---------------------------------------------|---------------|---------|-------------|----------------|-------------------|-------------------------------------------------------|
| id         | Identificador único da sugestão              | INT           | -       | Sim         | Sim            | Não               | Auto incremento                                        |
| usuarioId  | Identificador do usuário                      | INT           | -       | Sim         | Não            | Sim               | FK para tabela USUÁRIO                                 |
| eventoId   | Identificador do evento                       | INT           | -       | Sim         | Não            | Sim               | FK para tabela EVENTOS                                 |
| conteudo   | Conteúdo da sugestão                          | TEXT          | -       | Sim         | Não            | Não               |                                                       |
| dataEnvio  | Data e hora do envio                          | DATETIME      | -       | Sim         | Não            | Não               |                                                       |
| status     | Status da sugestão                            | NVARCHAR      | 20      | Não         | Não            | Não               | Valores: 'Nova', 'Em análise', 'Respondida' (opcional) |

---
