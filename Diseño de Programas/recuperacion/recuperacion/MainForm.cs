using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;	//Libreria para manipular los objetos del chart

namespace recuperacion{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form{
		
		/*Atributos (variables globales)*/
		// Crear una lista para almacenar los encabezados
		List<string> hutt = new List<string>();
		// Crear una lista para almacenar los paises
		List<string> pais = new List<string>();
		// Crear una lista para almacenar las fechas;
		List<string> fecha = new List<string>();
		// Lista para guardar todos los datos
		List<string[]> data = new List<string[]>();
		
		/*Metodos personalizados*/
		public void cambio(){
			//Variables locales
			
			double promedio = 0.0;
			long total = 0;
			List<string> tmp = new List<string>();
			
			int i = comboBox1.SelectedIndex+2;
			int j = comboBox2.SelectedIndex;
			
			foreach(string[] r in data){
				tmp.Add(r[i]);
				// FIXME: Se marca un error en la linea de abajo :( 
				/* total += Convert.ToInt32(r[i]); //Obtener la suma de valores*/
			}
			
			//Obtener Promedio 
			// FIXME: Por el error de arriba no pude sacar el promedio :(
			// promedio =(double)total / (double)tmp.Count;
			
			if(comboBox2.SelectedIndex != -1){
				textBox1.Text = tmp[j];
				textBox2.Text = fecha[j];
				textBox3.Text = ":("; 
			}
		}
		
		public MainForm(){
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		void MainFormLoad(object sender, EventArgs e){
			
			//PARA LA GRAFICA
			// Dar formato a la leyenda
			chart1.Legends[0].BackColor = Color.AliceBlue;
			chart1.Legends[0].BorderColor = Color.DarkBlue;
			
			// Variables locales
			int j = 0;		// Contador de líneas
			
			// Lectura del archivo CSV
			using(var lector = new StreamReader("covid.csv")){
				// Hasta el fin del archivo
				while(!lector.EndOfStream){
					// Leer línea por línea ('\n')
					var linia = lector.ReadLine();
					
					// Encabezado
					if(j == 0){
						// Recorrer elemento a elemento y añadir a una lista
						foreach(string en in linia.Split(','))
							hutt.Add(en);
					}
					else{
						// Añadir los elementos de la tabla
						data.Add(linia.Split(','));
						// Se añaden los paises
						pais.Add(linia.Split(',')[0] );
						fecha.Add(linia.Split(',')[1]);
					}
					// contador de líneas leídas
					j++;
				}
				
				/* Leídos los datos, comenzar a llenar los espacios de la GUI */
				hutt.RemoveRange(0,2);
				foreach(string p in hutt)
					comboBox1.Items.Add(p);
				comboBox1.Text = comboBox1.Items[0].ToString();
				
				// Colocar los paises
				foreach(string a in pais)
					comboBox2.Items.Add(a);
				comboBox2.Text = comboBox2.Items[0].ToString();
				
			}
		}
		
		void Button1Click(object sender, EventArgs e){
			chart1.Series["No. de casos"].Points.Clear();			//Limpiar la grafica
			chart1.Series["No. de casos"].IsValueShownAsLabel = true;
		}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e){
			cambio();
		}
		
		void ComboBox2SelectedIndexChanged(object sender, EventArgs e){
			cambio();
		}
		
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			
		}
		
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			
		}
	}
}
