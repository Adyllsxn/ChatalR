# 📘 Regras de Negócio (RN) – MVP do Sistema Kairos

| ID    | Nome                                 | Descrição                                                       |
|-------|--------------------------------------|------------------------------------------------------------------|
| RN01  | Validação no Cadastro                | Campos como nome, email e BI são obrigatórios.                  |
| RN02  | Senha Segura                         | Senhas devem usar hash e salt.                                  |
| RN03  | Permissões por Perfil                | Acesso conforme perfil: Admin, Organizador ou Membro.           |
| RN04  | Tipos de Evento                      | Apenas organizadores podem criar ou editar.                     |
| RN05  | Dados Obrigatórios em Evento         | Eventos exigem título, tipo, data, local e imagem.              |
| RN06  | Edição Limitada                      | Organizadores só podem editar/excluir seus próprios eventos.    |
| RN07  | Exibição de Eventos                  | Apenas eventos ativos e aprovados são visíveis.                 |
| RN08  | Confirmação Única de Presença        | Um usuário só pode confirmar presença uma vez por evento.       |
| RN09  | Histórico de Presença Pessoal        | Cada usuário só vê o próprio histórico.                         |
| RN10  | Publicação de Posts                  | Só organizadores publicam posts; apenas publicados são visíveis.|
