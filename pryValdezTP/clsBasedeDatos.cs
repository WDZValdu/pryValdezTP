using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;


namespace pryValdezTP
{
    internal class clsBasedeDatos
    {
        OleDbConnection conexionBD;
        OleDbCommand comandoBD;
        OleDbDataReader lectorBD;
        OleDbDataAdapter objDataAdap;
        DataSet objDataSet = new DataSet();
        public string EstadoConexion = "";
       
        public void ConectarBD()
        {
            try
            {
                conexionBD = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source = EMPLEADO.accdb");
                conexionBD.Open();
                EstadoConexion = "Conectado";
            }
            catch (Exception ex)
            {
                EstadoConexion = "Error: " + ex.Message;
            }
        }

        public void CargarUsuario(int varCodigo, string varNombre, string varApellido, DateTime varFecha
            , string varCiudad, string varDirreccion, string varTelefono)
        {
            ConectarBD();
            comandoBD = new OleDbCommand();

            comandoBD.Connection = conexionBD;


            // Establece el tipo de comando y la tabla
            comandoBD.CommandType = System.Data.CommandType.TableDirect;
            //Que tabla traigo
            comandoBD.CommandText = "DATOS PERSONALES";



            // crear el objeto DataAdapter pasando como parámetro el objeto comando que queremos vincular
            objDataAdap = new OleDbDataAdapter(comandoBD);
            // ejecutar la lectura de la tabla y almacenar su contenido en el dataAdapter
            objDataAdap.Fill(objDataSet, "DATOS PERSONALES");
            // obtenemos una referencia a la tabla


            DataTable dt = objDataSet.Tables["DATOS PERSONALES"];

            // creamos el nuevo DataRow con la estructura de campos de la tabla
            DataRow dr = dt.NewRow();
            // asignamos los valores a todos los campos del DataRow
            dr["CODIGO"] = varCodigo;
            dr["NOMBRE"] = varNombre;
            dr["APELLIDO"] = varApellido;
            dr["FECHA_NACIMIENTO"] = varFecha;
            dr["DIRECCIÒN"] = varDirreccion;
            dr["CIUDAD"] = varCiudad;
            dr["TELEFONO"] = varTelefono;
            // agregamos el DataRow a la tabla

            dt.Rows.Add(dr);

            // creamos el objeto OledBCommandBuilder pasando como parámetro el DataAdapter
            OleDbCommandBuilder cb = new OleDbCommandBuilder(objDataAdap);

            // actualizamos la base con los cambios realizados
            objDataAdap.Update(objDataSet, "DATOS PERSONALES");
            conexionBD.Close();

            MessageBox.Show("El Empleado se cargo correctamente");
        }

        public void TraerDatos(DataGridView grilla)
        {
            ConectarBD();
            grilla.Rows.Clear();
            //instancia un objeto en la memoria
            comandoBD = new OleDbCommand();

            comandoBD.Connection = conexionBD;
            comandoBD.CommandType = System.Data.CommandType.TableDirect;
            comandoBD.CommandText = "DATOS PERSONALES";

            lectorBD = comandoBD.ExecuteReader();

            grilla.Columns.Add("Codigo", "Codigo");
            grilla.Columns.Add("Nombre", "Nombre");
            grilla.Columns.Add("Apellido", "Apellido");
            grilla.Columns.Add("Direccion", "Direccion");
            grilla.Columns.Add("Ciudad", "Ciudad");
            grilla.Columns.Add("Telefono", "Telefono");
            grilla.Columns.Add("Fecha de nacimiento", "Fecha de nacimiento");
            
            //leo como si fuera un archivo
            if (lectorBD.HasRows)
            {
                while (lectorBD.Read())
                {
                
                    grilla.Rows.Add(lectorBD[0], lectorBD[1], lectorBD[2], lectorBD[3], lectorBD[4], lectorBD[5], lectorBD[6]);

                }

            }
        }
        int encontro = 0;
        public void BuscarPorApellido(string codigo, DataGridView grilla)
        {
            ConectarBD();
            grilla.Rows.Clear();
            comandoBD = new OleDbCommand();

            comandoBD.Connection = conexionBD;
            //q tipo de operacion quierp hacer y que me traiga TOD la tabla con el tabledirect
            comandoBD.CommandType = System.Data.CommandType.TableDirect;
            //Que tabla traigo
            comandoBD.CommandText = "DATOS PERSONALES";
            //abre la tabla y muestra por renglon
            lectorBD = comandoBD.ExecuteReader();


            //SI TIENE FILAS
            if (lectorBD.HasRows)
            {
                encontro = 0;
                while (lectorBD.Read()) //mientras pueda leer, mostrar (leer)
                {
                    if (lectorBD[2].ToString() == codigo)
                    {

                        //datosTabla += "-" + lectorBD[0]; //dato d la comlumna 0
                        //MessageBox.Show("El Cliente " + lectorBD[0] + " Existente", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        
                        
                        grilla.Rows.Add(lectorBD[0], lectorBD[1], lectorBD[2], lectorBD[3], lectorBD[4], lectorBD[5], lectorBD[6]);
                        encontro = 1;


                    }

                }
                conexionBD.Close();

                if (encontro == 0)
                {

                    MessageBox.Show("Apellido "+ codigo + " no esta cargado en el sistema");
                    TraerDatos(grilla);
                }
            }
        }
        public void BuscarPorCiudad(string codigo, DataGridView grilla)
        {
            ConectarBD();
            grilla.Rows.Clear();
            comandoBD = new OleDbCommand();

            comandoBD.Connection = conexionBD;
            //q tipo de operacion quierp hacer y que me traiga TOD la tabla con el tabledirect
            comandoBD.CommandType = System.Data.CommandType.TableDirect;
            //Que tabla traigo
            comandoBD.CommandText = "DATOS PERSONALES";
            //abre la tabla y muestra por renglon
            lectorBD = comandoBD.ExecuteReader();


            //SI TIENE FILAS
            if (lectorBD.HasRows)
            {
                encontro = 0;
                while (lectorBD.Read()) //mientras pueda leer, mostrar (leer)
                {
                    if (lectorBD[4].ToString() == codigo)
                    {

                        //datosTabla += "-" + lectorBD[0]; //dato d la comlumna 0
                        //MessageBox.Show("El Cliente " + lectorBD[0] + " Existente", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        

                        grilla.Rows.Add(lectorBD[0], lectorBD[1], lectorBD[2], lectorBD[3], lectorBD[4], lectorBD[5], lectorBD[6]);
                        encontro = 1;


                    }

                }
                conexionBD.Close();

                if (encontro == 0)
                {

                    MessageBox.Show("No se encontro ningun empleado cargado en la ciudad "+ codigo);
                    TraerDatos(grilla);

                }
            }
        }

    }
}
