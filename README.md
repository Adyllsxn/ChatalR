# KAIROS

**KAIROS** é uma plataforma web de compartilhamento de conteúdos acadêmicos entre estudantes. Permite que os usuários publiquem materiais como resumos, links, vídeos e PDFs, com organização por disciplina, comentários, curtidas e favoritos.

---

## ✨ Funcionalidades Principais

- ✅ Cadastro e login com autenticação JWT
- 📚 Upload de arquivos e links educacionais
- 🗂 Organização de conteúdos por disciplinas
- 🔍 Pesquisa por título, descrição ou autor
- 💬 Comentários e curtidas em conteúdos
- ⭐ Favoritos e listagem personalizada
- 👤 Perfil de usuário com histórico de postagens

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
├── test/                           # Testes automatizados
│   └── Kairos.Tests/               # Projeto de Testes unitários e Integração com xUnit
│       └── test.md                 # Explicação dos testes, bibliotecas e estrutura
│
├── .gitattributes                  # Define atributos de arquivos para Git (ex: fim de linha, linguagens)
├── .gitignore                      # Ignora arquivos/diretórios (ex: bin/, obj/, node_modules/)
├── LICENSE                         # Licença de uso do projeto (MIT, permissiva)
├── README.md                       # Introdução ao projeto, funcionalidades, estrutura e como rodar
└── Kairos.sln                      # Arquivo de solução do Visual Studio (.NET)
