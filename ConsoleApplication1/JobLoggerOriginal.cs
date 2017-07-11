//using System;
//using System.Linq;
//using System.Text;

////El codigo no compila 
//public class JobLogger
//{
//    private static bool _logToFile;
//    private static bool _logToConsole;
//    private static bool _logMessage;
//    private static bool _logWarning;
//    private static bool _logError;
//    ///En el caso de conservar esta variable debera adecuarse a la convencion tomada anteriormente es decir se debera
//    ///escribir _logToDataBase
//    private static bool LogToDatabase;
//    ///Esta variable no es utilizada debe eliminarse
//    private bool _initialized;
//    public JobLogger(bool logToFile, bool logToConsole, bool logToDatabase, bool
//    logMessage, bool logWarning, bool logError)
//    {
//        ///Crearia una clase de configuracion para poder setear todos estos valores y enviara la clase como parametro 
//        ///por lo tanto las valriables desaparecerian
//        _logError = logError;
//        _logMessage = logMessage;
//        _logWarning = logWarning;
//        LogToDatabase = logToDatabase;
//        _logToFile = logToFile;
//        _logToConsole = logToConsole;
//    }

//    ///bool message: Se debe cambiar el nombre del segundo Paramatero ya que posee el mismo nombre que el primero
//    ///una posibiliad de llamarlo seria bMessage
//    ///Debe quitarse el static ya que la clase no es statica y un metodo static debe se utilizado en una clase statica, la clase
//    ///JobLogger no es es tatica por lo tanto debe quitarse el static.
//    ///Deberia recibir un enum como valor para identificar el tipo de mensaje a logear.
//    public static void LogMessage(string message, bool message, bool warning, bool
//    error)
//    {
//        ///Dicha Validacion debera realizarse dentro de un metodo con un nombre representativo por ejemplo
//        ///ValidateMessage(message)
//        ///Relizar el metodo trim sin asignarselo al message no tiene sentido deberia ser asi
//        /// message = message.Trim();
//        /// si el message es null lanzaria una exepcion 
//        /// Se puede realziar todo en una linea utilizando el metodo IsNullWithSpace(message)
//            message.Trim();
//            if (message == null || message.Length == 0)
//            {
//                return;
//            }
//        ///
//        ///Dicha Validacion debera realizarse dentro de un metodo con un nombre representativo por ejemplo
//        ///ValidateConfiguration()
//            ///Esta validacion deberia realizarse en el constructor
//            if (!_logToConsole && !_logToFile && !LogToDatabase)
//            {
//                throw new Exception("Invalid configuration");
//            }
//            ///Esta validacion deberia realizarse en el constructor
//            if ((!_logError && !_logMessage && !_logWarning) ||
//             (!message && !warning&& !error))
//            {
//                throw new Exception("Error or Warning or Message must be specified");
//            }
//        ///


//        ///Dicha funcionalidad deberia estar en un metodo con un nombre representativo por ejemplo
//        ///LogInDataBase(message)
//            ///Se debe agregar la validacion si el logeador loguea por base de datos es de decir si la variable LogToDataBase = true
//            ///El ConectionString recuperado del app.config podria ser colocado en una variable y luego enviar 
//            ///la variable como parametro en el contructor del SqlConection(variable) para mayor proligidad
//            ///como desventaja creamos una variable de mas ocupando mas memoria y como ventaja el codigo es mas legible
//             System.Data.SqlClient.SqlConnection connection = new
//            System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
//            connection.Open();
//            //TODO
//            ///Utilizar nombre de variables representativos, por ejemplo typeMessage
//            int t;
//            if (message && _logMessage)
//            {
//                t = 1;
//            }
//            if (error && _logError)
//            {
//                t = 2;
//            }
//            if (warning && _logWarning)
//            {
//                t = 3;
//            }
//            ///La query enviada en el constructor podria guardarse primero en una variable para mayor proligidad
//            ///como desventaja creamos una variable de mas ocupando mas memoria y como ventaja el codigo es mas legible
//            ///Realizar la query de esta forma es inseguro ya que puede presterarse a inyecciones SQL
//            ///lo correcto seria realizarlo con Parameters en el command
//            System.Data.SqlClient.SqlCommand command = new
//            System.Data.SqlClient.SqlCommand("Insert into Log Values('" + message + "', " + t.ToString() + ")");
//            command.ExecuteNonQuery();
//        ///deberia realizar un Dispose() del command porque sino quedaria el command en Memoria
//        ///deberiamos cerrar la conexion a la base de datos connection.Close()  
//        ///o connection.Dispose() el cual eliminaria el objeto conexion de momemoria 
//        ///

//        ///Dicha funcionalidad deberia estar en un metodo con un nombre representativo por ejemplo
//        ///Se debe agregar la validacion si el logeador loguea por archivo es de decir si la variable LogToFile = true
//        ///LogInDataBase(message)
//        ///Utilizar nombre de variables representativos, por ejemplo newMessage
//        string l;
//            ///La ruta para leer o guardar el archivo deberia guardarse en una variable (path) para mayor proligidad y poder reutilizarla sin errores
//            ///La fecha tambien deberia guardarse en una variable tipo string (string DateNow) ya que es utilizada en muchos lugares
//            ///No deberia estar negado dentro del if
//                                        ///utilizar la varible path
//            if (!System.IO.File.Exists(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() + ".txt"))
//            {                              ///utilizar la varible path
//                l = System.IO.File.ReadAllText(System.Configuration.ConfigurationManager.AppSettings[" LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() + ".txt");
//            }
//            //En caso de no existir el archivo deberia crearse

//            ///Debera agregarse algun string para identifiar si es un error, un mensaje o un warning
//            ///la concatenacion del mensaje podria realizarse utilizando la clase StringBuilder y el metodo AppenLine
//        if (error && _logError)
//            {
//                l = l + DateTime.Now.ToShortDateString() + message;
//            }
//            if (warning && _logWarning)
//            {
//                l = l + DateTime.Now.ToShortDateString() + message;
//            }
//            if (message && _logMessage)
//            {
//                l = l + DateTime.Now.ToShortDateString() + message;
//            }
//                                        ///utilizar la varible path
//            System.IO.File.WriteAllText(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() + ".txt", l);

//            ///Otra alternativa para realizar el logueo en el archivo es simplmente escribir en el archivo al final del mismo 
//            ///sin necesidad de abrirlo esto lo podemos hacer con la clase FileStream y el metodo y el FileMode.Append

//        ///

//        ///Dicha funcionalidad deberia estar en un metodo con un nombre representativo por ejemplo
//        ///Se debe agregar la validacion si el logeador loguea por conosola es de decir si la variable LogToConsole = true
//        ///LogInConsole()
//        if (error && _logError)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//            }
//            if (warning && _logWarning)
//            {
//                Console.ForegroundColor = ConsoleColor.Yellow;
//            }
//            if (message && _logMessage)
//            {
//                Console.ForegroundColor = ConsoleColor.White;
//            }
//            Console.WriteLine(DateTime.Now.ToShortDateString() + message);
//        ///
//    }
//}