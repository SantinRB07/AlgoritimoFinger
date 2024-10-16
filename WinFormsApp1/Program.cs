using System;
using System.Drawing;
using System.Windows.Forms;

public class FormCalculoDPI : Form
{
    private Panel panelContainer;
    private PictureBox pictureBox;
    private Button btnSelecionarImagem;
    private TextBox txtDistanciaCm;
    private Button btnCalcularDPI;
    private Label lblResultadoDPI;
    private Label lblDistancia;
    private Point ponto1, ponto2;
    private bool primeiroPontoSelecionado = false;
    private Bitmap imagemOriginal;

    public FormCalculoDPI()
    {
        // Configuração do Form
        this.Text = "Calculadora de DPI";
        this.Size = new Size(800, 600);
        this.MinimumSize = new Size(800, 600); // Definir um tamanho mínimo para a janela

        // Painel de rolagem
        panelContainer = new Panel();
        panelContainer.Dock = DockStyle.Fill;  // O painel ocupará toda a área do formulário
        panelContainer.AutoScroll = true;      // Habilitar a rolagem automática
        panelContainer.AutoSize = true;        // Ajustar o tamanho conforme o conteúdo
        panelContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        this.Controls.Add(panelContainer);     // Adicionar o painel ao formulário

        // PictureBox para exibir a imagem
        pictureBox = new PictureBox();
        pictureBox.Size = new Size(600, 400);
        pictureBox.Location = new Point(100, 50);
        pictureBox.BorderStyle = BorderStyle.Fixed3D;
        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox.MouseClick += new MouseEventHandler(this.PictureBox_Click);
        panelContainer.Controls.Add(pictureBox); // Adicionar PictureBox ao painel

        // Botão para selecionar a imagem
        btnSelecionarImagem = new Button();
        btnSelecionarImagem.Text = "Selecionar Imagem";
        btnSelecionarImagem.Location = new Point(100, 470);
        btnSelecionarImagem.Click += new EventHandler(this.BtnSelecionarImagem_Click);
        panelContainer.Controls.Add(btnSelecionarImagem); // Adicionar botão ao painel

        // Campo de texto para inserir a distância em centímetros
        lblDistancia = new Label();
        lblDistancia.Text = "Distância real entre os pontos (em cm):";
        lblDistancia.Location = new Point(100, 510);
        panelContainer.Controls.Add(lblDistancia); // Adicionar label ao painel

        txtDistanciaCm = new TextBox();
        txtDistanciaCm.Location = new Point(350, 510);
        panelContainer.Controls.Add(txtDistanciaCm); // Adicionar campo de texto ao painel

        // Botão para calcular o DPI
        btnCalcularDPI = new Button();
        btnCalcularDPI.Text = "Calcular DPI";
        btnCalcularDPI.Location = new Point(100, 550);
        btnCalcularDPI.Click += new EventHandler(this.BtnCalcularDPI_Click);
        panelContainer.Controls.Add(btnCalcularDPI); // Adicionar botão ao painel

        // Label para exibir o resultado do DPI
        lblResultadoDPI = new Label();
        lblResultadoDPI.Text = "DPI: ";
        lblResultadoDPI.Location = new Point(350, 550);
        lblResultadoDPI.AutoSize = true;
        panelContainer.Controls.Add(lblResultadoDPI); // Adicionar label ao painel
    }

    // Função que permite selecionar a imagem
    private void BtnSelecionarImagem_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Imagens|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            // Carregar a imagem original
            imagemOriginal = new Bitmap(openFileDialog.FileName);
            pictureBox.Image = new Bitmap(imagemOriginal);
            ponto1 = Point.Empty;
            ponto2 = Point.Empty;
            primeiroPontoSelecionado = false;
        }
    }

    // Função que registra o clique nos pontos da imagem e desenha um símbolo
    private void PictureBox_Click(object sender, MouseEventArgs e)
    {
        if (pictureBox.Image == null)
            return;

        // Converte as coordenadas do clique para as coordenadas reais da imagem
        int x = (int)((float)e.X / pictureBox.Width * pictureBox.Image.Width);
        int y = (int)((float)e.Y / pictureBox.Height * pictureBox.Image.Height);

        using (Graphics g = Graphics.FromImage(pictureBox.Image))
        {
            // Desenhar um círculo no ponto clicado
            Pen pen = new Pen(Color.Red, 2);
            int tamanhoMarcacao = 15; // Tamanho da marcação visual (círculo)

            if (!primeiroPontoSelecionado)
            {
                ponto1 = new Point(x, y);
                primeiroPontoSelecionado = true;
                g.DrawEllipse(pen, ponto1.X - tamanhoMarcacao / 2, ponto1.Y - tamanhoMarcacao / 2, tamanhoMarcacao, tamanhoMarcacao);
                MessageBox.Show($"Ponto 1 selecionado: ({ponto1.X}, {ponto1.Y})"); //Indica as coordenadas do ponto 1 
            }
            else
            {
                ponto2 = new Point(x, y);
                g.DrawEllipse(pen, ponto2.X - tamanhoMarcacao / 2, ponto2.Y - tamanhoMarcacao / 2, tamanhoMarcacao, tamanhoMarcacao);
                MessageBox.Show($"Ponto 2 selecionado: ({ponto2.X}, {ponto2.Y})");//Indica as coordenadas do ponto 2 
            }
        }

        // Atualizar a imagem no PictureBox para refletir as marcações
        pictureBox.Invalidate();
    }

    // Função para calcular o DPI com base nos pontos e na distância em cm
    private void BtnCalcularDPI_Click(object sender, EventArgs e)
    {
        if (ponto1 == Point.Empty || ponto2 == Point.Empty)
        {
            MessageBox.Show("Por favor, selecione dois pontos na imagem.");
            return;
        }

        if (string.IsNullOrEmpty(txtDistanciaCm.Text) || !double.TryParse(txtDistanciaCm.Text, out double distanciaRealCm))
        {
            MessageBox.Show("Por favor, insira uma distância válida em centímetros.");
            return;
        }

        // Calcula a distância em pixels entre os dois pontos
        double distanciaPixels = Math.Sqrt(Math.Pow(ponto2.X - ponto1.X, 2) + Math.Pow(ponto2.Y - ponto1.Y, 2));

        // Calcula o DPI real
        double dpiCalculado = (distanciaPixels / distanciaRealCm) * 2.54;
        lblResultadoDPI.Text = $"DPI: {dpiCalculado:F2}";
    }

    // Função principal para rodar o formulário
    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new FormCalculoDPI());
    }
}
