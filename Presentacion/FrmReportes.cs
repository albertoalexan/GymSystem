using System.Drawing.Printing;
using System.Globalization;
using System.Text;
using GymSystem.Entidades;
using GymSystem.Negocio;

namespace GymSystem;

public sealed class FrmReportes : Form
{
    private readonly PagoService _pagoService = new();

    private readonly DateTimePicker _dtpDesde = new();
    private readonly DateTimePicker _dtpHasta = new();

    private readonly Button _btnGenerar = new();
    private readonly Button _btnExportar = new();
    private readonly Button _btnImprimir = new();

    private readonly DataGridView _dgvReporte = new();

    private readonly Label _lblTituloReporte = new();
    private readonly Label _lblPeriodo = new();
    private readonly Label _lblTotalRegistros = new();
    private readonly Label _lblMontoTotal = new();
    private readonly Label _lblEstado = new();

    private readonly PrintDocument _documentoImpresion = new();

    private List<Pago> _datos = new();
    private int _indiceImpresion;

    private static readonly CultureInfo CulturaMoneda =
        CultureInfo.GetCultureInfo("es-NI");

    public FrmReportes()
    {
        Text = "Reportes de pagos";
        BackColor = Color.FromArgb(241, 245, 249);
        ForeColor = Color.FromArgb(15, 23, 42);
        Font = new Font("Segoe UI", 9F);
        MinimumSize = new Size(850, 550);

        ConstruirInterfaz();

        _documentoImpresion.DefaultPageSettings.Landscape = true;
        _documentoImpresion.PrintPage += DocumentoImpresion_PrintPage;

        Load += async (_, _) =>
        {
            DateTime hoy = DateTime.Today;

            _dtpDesde.Value = new DateTime(
                hoy.Year,
                hoy.Month,
                1);

            _dtpHasta.Value = hoy;

            await GenerarReporteAsync();
        };

        _btnGenerar.Click += async (_, _) =>
            await GenerarReporteAsync();

        _btnExportar.Click += ExportarCsv_Click;
        _btnImprimir.Click += Imprimir_Click;

        FormClosed += (_, _) =>
            _documentoImpresion.Dispose();
    }

    private void ConstruirInterfaz()
    {
        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 4,
            Padding = new Padding(22),
            BackColor = BackColor
        };

        layout.ColumnStyles.Add(
            new ColumnStyle(SizeType.Percent, 100));

        layout.RowStyles.Add(
            new RowStyle(SizeType.Absolute, 58));

        layout.RowStyles.Add(
            new RowStyle(SizeType.Absolute, 76));

        layout.RowStyles.Add(
            new RowStyle(SizeType.Percent, 100));

        layout.RowStyles.Add(
            new RowStyle(SizeType.Absolute, 72));

        // Encabezado del reporte.
        var encabezado = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = BackColor
        };

        _lblTituloReporte.Text = "Reporte de pagos";
        _lblTituloReporte.Font =
            new Font("Segoe UI", 19F, FontStyle.Bold);

        _lblTituloReporte.AutoSize = true;
        _lblTituloReporte.Location = new Point(0, 0);

        _lblPeriodo.Text = "Selecciona un período para generar el reporte.";
        _lblPeriodo.AutoSize = true;
        _lblPeriodo.ForeColor = Color.FromArgb(71, 85, 105);
        _lblPeriodo.Location = new Point(2, 34);

        encabezado.Controls.Add(_lblTituloReporte);
        encabezado.Controls.Add(_lblPeriodo);

        // Filtros de fecha y botones.
        var filtros = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            AutoScroll = true,
            Padding = new Padding(0, 13, 0, 0),
            BackColor = BackColor
        };

        filtros.Controls.Add(CrearEtiqueta("Desde:"));

        _dtpDesde.Format = DateTimePickerFormat.Short;
        _dtpDesde.Width = 125;
        _dtpDesde.MaxDate = DateTime.Today;
        _dtpDesde.Margin = new Padding(5, 2, 16, 0);
        filtros.Controls.Add(_dtpDesde);

        filtros.Controls.Add(CrearEtiqueta("Hasta:"));

        _dtpHasta.Format = DateTimePickerFormat.Short;
        _dtpHasta.Width = 125;
        _dtpHasta.MaxDate = DateTime.Today;
        _dtpHasta.Margin = new Padding(5, 2, 16, 0);
        filtros.Controls.Add(_dtpHasta);

        ConfigurarBoton(
            _btnGenerar,
            "Generar",
            Color.FromArgb(37, 99, 235));

        ConfigurarBoton(
            _btnExportar,
            "Exportar CSV",
            Color.FromArgb(5, 122, 85));

        ConfigurarBoton(
            _btnImprimir,
            "Vista previa",
            Color.FromArgb(51, 65, 85));

        _btnExportar.Enabled = false;
        _btnImprimir.Enabled = false;

        filtros.Controls.Add(_btnGenerar);
        filtros.Controls.Add(_btnExportar);
        filtros.Controls.Add(_btnImprimir);

        // Tabla de resultados.
        _dgvReporte.Dock = DockStyle.Fill;
        _dgvReporte.ReadOnly = true;
        _dgvReporte.AllowUserToAddRows = false;
        _dgvReporte.AllowUserToDeleteRows = false;
        _dgvReporte.AllowUserToResizeRows = false;
        _dgvReporte.MultiSelect = false;
        _dgvReporte.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        _dgvReporte.AutoGenerateColumns = false;
        _dgvReporte.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

        _dgvReporte.RowHeadersVisible = false;
        _dgvReporte.BackgroundColor = Color.White;
        _dgvReporte.BorderStyle = BorderStyle.None;
        _dgvReporte.GridColor = Color.FromArgb(226, 232, 240);
        _dgvReporte.EnableHeadersVisualStyles = false;

        _dgvReporte.ColumnHeadersDefaultCellStyle.BackColor =
            Color.FromArgb(226, 232, 240);

        _dgvReporte.ColumnHeadersDefaultCellStyle.ForeColor =
            Color.FromArgb(15, 23, 42);

        _dgvReporte.ColumnHeadersDefaultCellStyle.Font =
            new Font("Segoe UI", 9F, FontStyle.Bold);

        _dgvReporte.ColumnHeadersHeight = 38;
        _dgvReporte.RowTemplate.Height = 32;

        _dgvReporte.Columns.Add(
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Pago.IdPago),
                HeaderText = "N.º pago",
                FillWeight = 70
            });

        _dgvReporte.Columns.Add(
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Pago.Fecha),
                HeaderText = "Fecha",
                FillWeight = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy"
                }
            });

        _dgvReporte.Columns.Add(
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Pago.NombreCliente),
                HeaderText = "Cliente",
                FillWeight = 150
            });

        _dgvReporte.Columns.Add(
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Pago.NombrePlan),
                HeaderText = "Plan",
                FillWeight = 135
            });

        _dgvReporte.Columns.Add(
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Pago.Monto),
                HeaderText = "Monto",
                FillWeight = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "C2",
                    Alignment =
                        DataGridViewContentAlignment.MiddleRight
                }
            });

        _dgvReporte.Columns.Add(
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Pago.MetodoPago),
                HeaderText = "Método de pago",
                FillWeight = 125
            });

        // Totales y estado.
        var pie = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 3,
            RowCount = 2,
            BackColor = BackColor,
            Padding = new Padding(0, 8, 0, 0)
        };

        pie.ColumnStyles.Add(
            new ColumnStyle(SizeType.Percent, 30));

        pie.ColumnStyles.Add(
            new ColumnStyle(SizeType.Percent, 35));

        pie.ColumnStyles.Add(
            new ColumnStyle(SizeType.Percent, 35));

        pie.RowStyles.Add(
            new RowStyle(SizeType.Absolute, 27));

        pie.RowStyles.Add(
            new RowStyle(SizeType.Absolute, 24));

        _lblTotalRegistros.Text = "Pagos: 0";
        _lblTotalRegistros.AutoSize = true;
        _lblTotalRegistros.Font =
            new Font("Segoe UI", 9F, FontStyle.Bold);

        _lblMontoTotal.Text = "Total recibido: C$ 0.00";
        _lblMontoTotal.AutoSize = true;
        _lblMontoTotal.Font =
            new Font("Segoe UI", 9F, FontStyle.Bold);

        _lblEstado.Text = "Listo";
        _lblEstado.AutoSize = true;
        _lblEstado.ForeColor =
            Color.FromArgb(71, 85, 105);

        pie.Controls.Add(_lblTotalRegistros, 0, 0);
        pie.Controls.Add(_lblMontoTotal, 1, 0);
        pie.Controls.Add(_lblEstado, 0, 1);
        pie.SetColumnSpan(_lblEstado, 3);

        layout.Controls.Add(encabezado, 0, 0);
        layout.Controls.Add(filtros, 0, 1);
        layout.Controls.Add(_dgvReporte, 0, 2);
        layout.Controls.Add(pie, 0, 3);

        Controls.Add(layout);
    }

    private static Label CrearEtiqueta(string texto)
    {
        return new Label
        {
            Text = texto,
            AutoSize = true,
            Margin = new Padding(0, 8, 2, 0),
            ForeColor = Color.FromArgb(51, 65, 85)
        };
    }

    private static void ConfigurarBoton(
        Button boton,
        string texto,
        Color color)
    {
        boton.Text = texto;
        boton.Width = texto == "Exportar CSV" ? 115 : 100;
        boton.Height = 34;
        boton.Margin = new Padding(4, 0, 7, 0);

        boton.FlatStyle = FlatStyle.Flat;
        boton.FlatAppearance.BorderSize = 0;

        boton.BackColor = color;
        boton.ForeColor = Color.White;
        boton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        boton.Cursor = Cursors.Hand;
        boton.UseVisualStyleBackColor = false;
    }

    private async Task GenerarReporteAsync()
    {
        DateTime desde = _dtpDesde.Value.Date;
        DateTime hasta = _dtpHasta.Value.Date;

        if (desde > hasta)
        {
            MessageBox.Show(
                "La fecha inicial no puede ser posterior a la fecha final.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            _dtpDesde.Focus();
            return;
        }

        _btnGenerar.Enabled = false;
        _btnExportar.Enabled = false;
        _btnImprimir.Enabled = false;

        _lblEstado.Text = "Consultando la base de datos...";

        try
        {
            _datos = await _pagoService.GenerarReporteAsync(
                desde,
                hasta);

            _dgvReporte.DataSource = null;
            _dgvReporte.DataSource = _datos;

            decimal total = _datos.Sum(p => p.Monto);

            _lblPeriodo.Text =
                $"Período: {desde:dd/MM/yyyy} - {hasta:dd/MM/yyyy}";

            _lblTotalRegistros.Text =
                $"Cantidad de pagos: {_datos.Count}";

            _lblMontoTotal.Text =
                $"Total recibido: C$ {total.ToString("N2", CulturaMoneda)}";

            _lblEstado.Text = _datos.Count == 0
                ? "No hay pagos para el período seleccionado."
                : $"Reporte generado: {DateTime.Now:dd/MM/yyyy HH:mm}";

            _btnExportar.Enabled = _datos.Count > 0;
            _btnImprimir.Enabled = _datos.Count > 0;
        }
        catch (Exception ex)
        {
            _lblEstado.Text = "No se pudo generar el reporte.";

            MessageBox.Show(
                "No fue posible generar el reporte de pagos.\n\n" +
                ex.Message,
                "Error de reporte",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            _btnGenerar.Enabled = true;
        }
    }

    private void ExportarCsv_Click(
        object? sender,
        EventArgs e)
    {
        if (_datos.Count == 0)
        {
            MessageBox.Show(
                "No hay datos que exportar.",
                "Reportes",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return;
        }

        using var dialogo = new SaveFileDialog
        {
            Title = "Exportar reporte de pagos",
            Filter = "Archivo CSV (*.csv)|*.csv",
            DefaultExt = "csv",
            AddExtension = true,
            FileName =
                $"ReportePagos_{_dtpDesde.Value:yyyyMMdd}_{_dtpHasta.Value:yyyyMMdd}.csv"
        };

        if (dialogo.ShowDialog(this) != DialogResult.OK)
            return;

        try
        {
            using var escritor = new StreamWriter(
                dialogo.FileName,
                false,
                new UTF8Encoding(true));

            escritor.WriteLine(
                EscaparCsv("GYMSYSTEM - REPORTE DE PAGOS"));

            escritor.WriteLine(
                EscaparCsv(
                    $"Período: {_dtpDesde.Value:dd/MM/yyyy} - {_dtpHasta.Value:dd/MM/yyyy}"));

            escritor.WriteLine(
                EscaparCsv($"Cantidad de pagos: {_datos.Count}"));

            escritor.WriteLine(
                EscaparCsv(
                    $"Total recibido: C$ {_datos.Sum(p => p.Monto).ToString("N2", CulturaMoneda)}"));

            escritor.WriteLine();

            escritor.WriteLine(
                string.Join(
                    ",",
                    new[]
                    {
                        "N.º pago",
                        "Fecha",
                        "Cliente",
                        "Plan",
                        "Monto",
                        "Método de pago"
                    }.Select(EscaparCsv)));

            foreach (Pago pago in _datos)
            {
                escritor.WriteLine(
                    string.Join(
                        ",",
                        new[]
                        {
                            EscaparCsv(pago.IdPago.ToString()),
                            EscaparCsv(pago.Fecha.ToString("dd/MM/yyyy")),
                            EscaparCsv(pago.NombreCliente),
                            EscaparCsv(pago.NombrePlan),
                            EscaparCsv(pago.Monto.ToString("0.00", CultureInfo.InvariantCulture)),
                            EscaparCsv(pago.MetodoPago)
                        }));
            }

            MessageBox.Show(
                "El reporte se exportó correctamente.",
                "Exportación completada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "No fue posible exportar el reporte.\n\n" +
                ex.Message,
                "Error de exportación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private static string EscaparCsv(string? valor)
    {
        string contenido = (valor ?? string.Empty)
            .Replace("\"", "\"\"");

        return "\"" + contenido + "\"";
    }

    private void Imprimir_Click(
        object? sender,
        EventArgs e)
    {
        if (_datos.Count == 0)
            return;

        try
        {
            _indiceImpresion = 0;

            using var vistaPrevia = new PrintPreviewDialog
            {
                Document = _documentoImpresion,
                Width = 1100,
                Height = 750,
                StartPosition = FormStartPosition.CenterParent
            };

            vistaPrevia.ShowDialog(this);

            _indiceImpresion = 0;
        }
        catch (Exception ex)
        {
            _indiceImpresion = 0;

            MessageBox.Show(
                "No fue posible preparar la vista previa de impresión.\n\n" +
                ex.Message,
                "Error de impresión",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void DocumentoImpresion_PrintPage(
        object? sender,
        PrintPageEventArgs e)
    {
        Graphics? graphics = e.Graphics;

        if (graphics is null)
        {
            e.HasMorePages = false;
            return;
        }

        Rectangle bounds = e.MarginBounds;

        using var fuenteTitulo =
            new Font("Segoe UI", 16F, FontStyle.Bold);

        using var fuenteNormal =
            new Font("Segoe UI", 9F);

        using var fuenteNegrita =
            new Font("Segoe UI", 9F, FontStyle.Bold);

        using var formato =
            new StringFormat
            {
                Trimming = StringTrimming.EllipsisCharacter,
                FormatFlags = StringFormatFlags.NoWrap,
                LineAlignment = StringAlignment.Center
            };

        float y = bounds.Top;

        graphics.DrawString(
            "GYMSYSTEM - REPORTE DE PAGOS",
            fuenteTitulo,
            Brushes.Black,
            bounds.Left,
            y);

        y += 32;

        graphics.DrawString(
            $"Período: {_dtpDesde.Value:dd/MM/yyyy} - {_dtpHasta.Value:dd/MM/yyyy}",
            fuenteNormal,
            Brushes.Black,
            bounds.Left,
            y);

        y += 20;

        graphics.DrawString(
            $"Cantidad de pagos: {_datos.Count}    Total recibido: C$ {_datos.Sum(p => p.Monto).ToString("N2", CulturaMoneda)}",
            fuenteNegrita,
            Brushes.Black,
            bounds.Left,
            y);

        y += 32;

        string[] encabezados =
        {
            "N.º pago",
            "Fecha",
            "Cliente",
            "Plan",
            "Monto",
            "Método"
        };

        float[] proporciones =
        {
            0.09F,
            0.13F,
            0.24F,
            0.22F,
            0.15F,
            0.17F
        };

        float[] anchuras = proporciones
            .Select(p => bounds.Width * p)
            .ToArray();

        float xInicial = bounds.Left;
        const int altoFila = 25;

        float x = xInicial;

        for (int i = 0; i < encabezados.Length; i++)
        {
            var rectangulo = new RectangleF(
                x,
                y,
                anchuras[i],
                altoFila);

            graphics.FillRectangle(
                Brushes.LightGray,
                rectangulo);

            graphics.DrawRectangle(
                Pens.Gray,
                Rectangle.Round(rectangulo));

            graphics.DrawString(
                encabezados[i],
                fuenteNegrita,
                Brushes.Black,
                rectangulo,
                formato);

            x += anchuras[i];
        }

        y += altoFila;

        while (_indiceImpresion < _datos.Count)
        {
            if (y + altoFila > bounds.Bottom)
            {
                e.HasMorePages = true;
                return;
            }

            Pago pago = _datos[_indiceImpresion];

            string[] valores =
            {
                pago.IdPago.ToString(),
                pago.Fecha.ToString("dd/MM/yyyy"),
                pago.NombreCliente,
                pago.NombrePlan,
                pago.Monto.ToString("C2", CulturaMoneda),
                pago.MetodoPago
            };

            x = xInicial;

            for (int i = 0; i < valores.Length; i++)
            {
                var rectangulo = new RectangleF(
                    x,
                    y,
                    anchuras[i],
                    altoFila);

                graphics.DrawRectangle(
                    Pens.LightGray,
                    Rectangle.Round(rectangulo));

                graphics.DrawString(
                    valores[i],
                    fuenteNormal,
                    Brushes.Black,
                    rectangulo,
                    formato);

                x += anchuras[i];
            }

            y += altoFila;
            _indiceImpresion++;
        }

        e.HasMorePages = false;
    }
}
