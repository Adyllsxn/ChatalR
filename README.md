# KAIROS (Gestão de Eventos e Cultos)

**Kairos** é uma plataforma web desenvolvida para auxiliar igrejas na gestão de cultos, eventos e presença de membros. Com uma abordagem moderna, o sistema organiza e automatiza processos como o cadastro de eventos, controle de participantes, visualização de conteúdos e administração de perfis.

> 💡 MVP desenvolvido no contexto de estágio curricular, com foco na Igreja Sossego em Cristo – UTANGA.

---

## ✨ Funcionalidades Principais

- ✅ **Cadastro e autenticação de usuários** (com perfis de Membro, Organizador e Administrador)
- 📅 **Criação, edição e listagem de eventos** e cultos
- ⛪ **Classificação por tipo de evento** (ex: Culto, Vigília, Ensaio)
- 🧾 **Registro de presença (check-in digital)** com histórico individual
- 👥 **Gestão de membros e organizadores**
- 📝 **Publicação de posts no blog da igreja**
- 📊 **Dashboard com gráficos de participação**
- 🔐 **Permissões por perfil e segurança de dados**

---

## 🚀 Tecnologias Utilizadas

- **Backend**: ASP.NET Core, EF Core, SQL Server
- **Frontend**: React.js, Vite
- **Testes**: xUnit, Moq
- **Infraestrutura**: Docker, JWT, Swagger
- **CI/CD**: GitHub Actions

---

## 📁 Estrutura do Projeto

```bash
KAIROS/
│
├── .github/                        # Configurações de CI/CD com GitHub Actions
│   ├── workflows/
│   │   └── (ex: Applicatio.yml)    # Arquivos de automação para build/teste
│   │    
│   └── workflows.md                #Explica os fluxos automatizados (CI/CD)  
│
├── .vscode/                        # Configs de ambiente para o VSCode (ex: launch.json, settings.json)
│
├── doc/                            # Documentação geral do projeto
│   ├── blueprint/                  # Documentação técnica e de requisitos
│   │   ├── DD.md                   # Dicionario de Dados
│   │   ├── Overview.md             # Visão geral, objetivos, funcionalidades e futuras melhorias
│   │   ├── RN.md                   # Regras de negócio
│   │   ├── RF.md                   # Requisitos funcionais
│   │   ├── RNF.md                  # Requisitos não funcionais
│   │   └── Setup.md                # Guia de instalação e uso local (manual do dev)
│   └── visual/                     # Diagramas, wireframes, fluxogramas etc. (a adicionar)
│
├── src/                            # Código-fonte principal
│   ├── backend/                    # Projeto ASP.NET Core (API REST)
│   │   ├── Kairos.Application/     # Casos de uso e lógica de aplicação
│   │   ├── Kairos.Domain/          # Entidades e regras de domínio
│   │   ├── Kairos.Infrastructure/  # Persistência, repositórios, external services
│   │   ├── Kairos.Presentation/    # Controllers e configurações de API
│   │   └── backend.md              # Documentação explicando a arquitetura e libs usadas
│   │
│   ├── frontend/                   # Projeto React com Vite
│   │   ├── kairos-web/             # Código do frontend (componentes, páginas, serviços)
│   │   └── frontend.md             # Explicação da stack e organização do frontend
│
├── .gitattributes                  # Define atributos de arquivos para Git (ex: fim de linha, linguagens)
├── .gitignore                      # Ignora arquivos/diretórios (ex: bin/, obj/, node_modules/)
├── LICENSE                         # Licença de uso do projeto (MIT, permissiva)
├── README.md                       # Introdução ao projeto, funcionalidades, estrutura e como rodar
└── Kairos.sln                      # Arquivo de solução do Visual Studio (.NET)
```

---

## Demo Screeshots

![Kairos Desktop Demo](./doc/visual/wireframe/web/desktop.png "Desktop Demo")

![Kairos Mobile Demo](./doc/visual/wireframe/web/mobile.png "Mobile Demo")
