# AlgoritimoFinger

Este projeto é uma aplicação Windows Forms em C# que permite carregar uma imagem, marcar dois pontos na imagem e calcular o DPI real com base na distância entre os dois pontos selecionados. A interface gráfica permite a seleção de pontos com visualização gráfica e a inserção da distância real ( em centímetros) entre eles para o cálculo

## Funcionalidades

- **Seleção de Imagem**: Permite ao usuário carregar uma imagem de um diretório local.
- **Marcação de Pontos**: O usuário pode clicar em dois pontos na imagem, e eles serão marcados com círculos vermelhos.
- **Cálculo de DPI**: Após marcar os pontos, o usuário insere a distância real entre os pontos (em centímetros), e o programa calcula o DPI da imagem.
- **Interface com rolagem**: A interface adapta-se a diferentes resoluções de tela e permite rolar para acessar todos os controles.

## Pré-requisitos

Para rodar este projeto, você precisará de:

- **.NET Framework ou .NET Core SDK** instalado.
  - Você pode baixar o SDK do .NET [aqui](https://dotnet.microsoft.com/download).
- Um ambiente de desenvolvimento compatível, como **Visual Studio**.

## Instruções de Instalação

1. **Clonar ou baixar o repositório**:
   - Clone o repositório do projeto ou baixe os arquivos e extraia em uma pasta local.

   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git
   ```

   ## Instruções de Instalação

2. **Abrir o projeto no Visual Studio**:
   - No Visual Studio, vá em **Arquivo > Abrir > Projeto/Solução** e selecione o arquivo `WindowsAPP1.csproj` ou `.sln` do projeto.

3. **Instalar a biblioteca System.Drawing**:
   -digite esse seguinte comando no terminal, na pasta que contém o projeto o arquvio `.csproj`.
   ```bash
    dotnet add package System.Drawing.Common
   ```

   ## Como Usar

### 1. Executar o Programa
Após compilar, execute o programa clicando em **Iniciar** ou pressionando `F5` no Visual Studio.

### 2. Selecionar a Imagem

- Clique no botão **Selecionar Imagem**.
- Navegue até a imagem desejada no seu computador e clique em **Abrir**.

### 3. Marcar os Pontos na Imagem

- Após a imagem ser carregada, clique sobre dois pontos diferentes na imagem que você deseja medir.
- Ao clicar no primeiro ponto, um círculo vermelho será desenhado e as coordenadas do ponto serão mostradas.
- Ao clicar no segundo ponto, outro círculo será desenhado, conectando os dois pontos com uma linha imaginária.

### 4. Inserir a Distância Real entre os Pontos

- Abaixo da imagem, insira a distância real entre os dois pontos (em centímetros) no campo de texto.

### 5. Calcular o DPI

- Clique no botão **Calcular DPI**. O DPI será calculado e exibido na parte inferior da interface.

