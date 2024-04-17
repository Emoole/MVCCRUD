# MVCCRUD
	1. CREAR LA BASE DE DATOS 
		a. BASE DE DATOS
		b. TABLAS
		c. PROCEDIMIENTOS
	2. CREAR NUEVO PROYECTO EN C# |WINDOWS | MVC .NET 6.0
	3. CARPETAS INICIALES (MODELS, CONTROLLERS, VIEWS)
	4. EN LA CARPETA MODEL - CREAREMOS EL MODELO con una clase ContactoModel
		a. Agregamos las propiedades que son las mismas columnas de la tabla {PROP TAB}
			i. Public int IdContacto{get; set}
			ii. Public string? Nombre{get; set}
			iii. Public string? Telefono{get; set}
			iv. Public string? Correo{get; set}
	5. En appsettings, definimos la cadena de conexion.
		a. "ConnectionString":{
		"CadenaSQL":"Data Source=local ; Initial Catalog=DBELIANA; Integrated Security=true"}
	6. Instalar el paquete de sqlClient
		a. Administrar paquetes nuget y buscar system.data.sqlclient
	7. CREAR CARPETA PARA LAS CONEXINES DE CLASE Y ACCESO A LOS SP DE LA BASE DE DATOS.
		a. Nueva carpeta>Datos>CLASE "conexion"
			i. Utilizaremos ADO.NET
			ii. A;adimos la referencia using System.Data.SqlClient;
			iii. Creamos una variable tipo privada string 
				Private string cadenaSQL= string.Empty;
			iv. Creamos el constructor para obtener la cadena de conexion
					Public Conexion(){
					Var builder =new configurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json").Build()
					
					//Acceder a la cadena en appsettings
					cadenaSQL=builder.getSection("ConnectionStrings:CadenaSQL").Value;
					}
			v. Crear un metodo para devolver la cadena
					Public strin getCadenaSQL(){
					Return cadenaSQL;
					}
	8. CREAR CLASE PARA ACCEDER A LOS PROCEDIMIENTOS ALMACENADOS
		a. Agregamos la clase en la carpeta DATOS 'contactoDatos.cs'
		Agregamos la referencia modelos
		Using CRUDCORE.Models;
		using System.Data.SqlClient;
		Using System.Data
		b. Creamos el primer metodo para consultar los registros
			Public List<ContactoModel> Listar(){
			Var olista= new List<ContactoModel>();
			#Instanciar la clase conexion
			Var cn=new Conexion();
			
			Using(var conexion= new SqlConnection(cn.getCadenaSQL())){
				Conexion.Open()
				SqlCommand cmd= new SqlCommand("SP_LISTAR",conexion);
				Cmd.CommandType=CommandType.StoredProcedure;
				
				Using(var dr=cmd.ExecuteReader()){
				While (dr.Read()){
					oLista.Add(new ContactoModel(){
					IdContacto=Convert.ToInt32(dr["IdContacto"]),
					Nombre=(dr["Nombre"]).ToString(),
					Telefono=(dr["Telefono"]).ToString(),
					Correo=(dr["Correo"]).ToString()
					
					})
				}
				}
			}
			Return oLista;
			}
		c. Metodo para obtener un registro especifico
			Public ContactModel Obtener(int IdContacto){
			
			Var oContacto=new ContactoModel();
			
			#Instanciar la clase conexion
			Var cn=new Conexion()
			
			Using(var conexion=new SqlConnection(cn.getCadenaSQL())){
			Conexion.Open()
			SqlCommand cmd= new SqlCommand("SP_OBTENER",conexion);
			#Parametros del SP
			Cmd.parameters.AddWithValue('IdContacto',IdContacto)
			Cmd.CommandType=CommandType.StoredProcedure;
			
			
			Using (var dr=cmd.ExecuteReader()){
				While(dr.Read()){
				oContacto.IdContacto=Convert.ToInt32(dr["Nombre"]);
				oContacto.Nombre=(dr["Nombre"]).ToString();
				oContacto.Telefono=(dr["Telefono"]).ToString();
				oContacto.Correo=(dr["Correo"]).ToString();
				}
			}
			}
			Return oContacto;
			}
		d. Metodo para guardar Registro en la tabla
			Public bool Guardar(ContactoModel oContacto){
			
			Bool rpta;
			Try
			{
			#Instanciar la clase conexion
			Var cn=new Conexion()
			
			Using(var conexion=new SqlConnection(cn.getCadenaSQL())){
			Conexion.Open()
			SqlCommand cmd= new SqlCommand("SP_GUARDAR",conexion);
			#Parametros del SP
			Cmd.parameters.AddWithValue('Nombre',oContacto.Nombre)
			Cmd.parameters.AddWithValue('Telefono',oContacto.Telefono)
			Cmd.parameters.AddWithValue('Correo',oContacto.Correo)
			#Tipo de comando
			Cmd.CommandType=CommandType.StoredProcedure;
			
			#Executar el comando
			Cmd.ExecuteNonQuery():
	
			}
			Rpta=true
			
			}
			Catch(Exception e){
			
			String error=e.Message;
			Rpta=false
			}
			
			Return rpta;
			}
			
		a. Metodo para Editar Registro
		Public bool Editar(ContactoModel oContacto){
		
		Bool rpta;
		Try
		{
		#Instanciar la clase conexion
		Var cn=new Conexion()
		
		Using(var conexion=new SqlConnection(cn.getCadenaSQL())){
		Conexion.Open()
		SqlCommand cmd= new SqlCommand("SP_EDITAR",conexion);
		#Parametros del SP
		Cmd.parameters.AddWithValue('IdContacto',oContacto.IdContacto)
		Cmd.parameters.AddWithValue('Nombre',oContacto.Nombre)
		Cmd.parameters.AddWithValue('Telefono',oContacto.Telefono)
		Cmd.parameters.AddWithValue('Correo',oContacto.Correo)
		#Tipo de comando
		Cmd.CommandType=CommandType.StoredProcedure;
		
		#Executar el comando
		Cmd.ExecuteNonQuery():

		}
		Rpta=true
		
		}
		Catch(Exception e){
		
		String error=e.Message;
		Rpta=false
		}
		
		Return rpta;
		}
		
		Metodo Eliminar Registro
		Public bool Editar(int IdContacto){
		
		Bool rpta;
		Try
		{
		#Instanciar la clase conexion
		Var cn=new Conexion()
		
		Using(var conexion=new SqlConnection(cn.getCadenaSQL())){
		Conexion.Open()
		SqlCommand cmd= new SqlCommand("SP_ELIMINAR",conexion);
		#Parametros del SP
		Cmd.parameters.AddWithValue('IdContacto',IdContacto)
		#Tipo de comando
		Cmd.CommandType=CommandType.StoredProcedure;
		
		#Executar el comando
		Cmd.ExecuteNonQuery():

		}
		Rpta=true
		
		}
		Catch(Exception e){
		
		String error=e.Message;
		Rpta=false
		}
		
		Return rpta;
		}
		
	9. CREAR CONTROLADOR DESDE CERO
		a. Controllers>crear nuev controlador MVC en Blanco "MantenedorController.cs"
		b. Agregamos las referencias necesarias 
			Using CRUDCORE.Datos;
			Using CRUDCORE.Models;
		c. REFERENCIA A LA CLASE CONTACTO DATOS
			ContactoDatos _ContactoDatos=new ContactoDatos();
			
		d. Cambiamos el metodo index
			Public IActionResult Listar(){
			#Mostrara la lista de contactos
			
			Var oLista= _ContactoDatos.Listar();
			
			
			Return View(oLista);
			}
			
		e. Creamos el metodo Guardar() #Para mostrar el formulario
			Public IActionResult Guardar(){
			#Solo Devuelve la Vista
			Return View();
			}
			
		f. Creamos el metodo Guardar() #Para obtener los datos del formulario y hacer la accion con la base de datos
		
			[HttpPost]
			Public IActionResult Guardar(ContactoModel oContacto){
			#Recibe el objeto para guardarlo en base de datos
			Var respuesta=_ContactoDatos.Guardar(oContacto)
			
			If(Respuesta)
				Return RedirectToAction('Listar');
			else
			        Return View();
			}
			
	
	10. TVISTAS
		a. Creamos las vistas. En el metodo Listar damos click derecho crear vista.
		Vista RAZOR > PLANTILLA EMPTY
		PAGINA DE DISENO>SHARED>LAYOUT.CSHTML
![image](https://github.com/Emoole/MVCCRUD/assets/42893169/a7c0ec70-c57c-4942-94de-fc9b248749b1)
