# DICIONÁRIO DE DADOS

---

## TABELA => TIPO DE EVENTOS

- **Nome do Campo**: ID.
- **Descrição**: Identificador da tabela.
- **Tipo de Dados**: INT.
- **Tamanho**: -
- **Obrigação**: Sim.
- **Chave Primária**: Sim.
- **Chave Secundária**: Não.
- **Observação**: Gearado Automaticamente

- **Nome do Campo**: Nome
- **Descrição**: Nome do Evento.
- **Tipo de Dados**: NVARCHAR.
- **Tamanho**: 50.
- **Obrigação**: Sim.
- **Chave Primária**: Não.
- **Chave Secundária**: Não.
- **Observação**: Deve Ser Único.

---

## TABELA => EVENTOS

- **Nome do Campo**: ID.
- **Descrição**: Identificador da tabela.
- **Tipo de Dados**: INT.
- **Tamanho**: -.
- **Obrigação**: Sim.
- **Chave Primária**: Sim.
- **Chave Secundária**: Não.
- **Observação**: Gearado Automaticamente

- **Nome do Campo**: Nome
- **Descrição**: Nome do Evento.
- **Tipo de Dados**: NVARCHAR.
- **Tamanho**: 50.
- **Obrigação**: Sim.
- **Chave Primária**: Não.
- **Chave Secundária**: Não.
- **Observação**: Deve Ser Único.

- **Nome do Campo**: Descricao
- **Descrição**: Detalhes (Informações) do Evento.
- **Tipo de Dados**: NVARCHARMAX.
- **Tamanho**: -.
- **Obrigação**: Sim.
- **Chave Primária**: Não.
- **Chave Secundária**: Não.
- **Observação**: Deve Ser Preenchido Manualmente as Informações do Evento ou Culto.

- **Nome do Campo**: Imagem
- **Descrição**: Imagem do Evento.
- **Tipo de Dados**: NVARCHARMAX.
- **Tamanho**: -.
- **Obrigação**: Sim.
- **Chave Primária**: Não.
- **Chave Secundária**: Não.
- **Observação**: Deve Ser Colocado a Imagem (Panfleto) do Evento ou Culto.

- **Nome do Campo**: TipoEventoID
- **Descrição**: Identificador do Tipo deEvento.
- **Tipo de Dados**: INT.
- **Tamanho**: -.
- **Obrigação**: Sim.
- **Chave Primária**: Não.
- **Chave Secundária**: Sim.
- **Observação**: Deve Ser Único.

- **Nome do Campo**: DataEvento
- **Descrição**: Data de Agendamento do Evento e Culto.
- **Tipo de Dados**: DATE.
- **Tamanho**: -.
- **Obrigação**: Sim.
- **Chave Primária**: Não.
- **Chave Secundária**: Não.
- **Observação**: Deve Ser Preenchido Automaticamente.

---
