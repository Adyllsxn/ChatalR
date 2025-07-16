name: Frontend CI/CD

on:
  push:
    branches:
      - develop

jobs:
  build:
    runs-on: ubuntu-latest

    steps:
      - name: Checkout repository
        uses: actions/checkout@v3

      - name: Setup Node.js
        uses: actions/setup-node@v3
        with:
          node-version: '20.19.1'

      - name: Install dependencies
        run: npm ci
        working-directory: src/frontend/kairos

      - name: Run Linter
        run: npm run lint
        working-directory: src/frontend/kairos

      - name: Build project
        run: npm run build
        working-directory: src/frontend/kairos