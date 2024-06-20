using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.DataAccess;
using AdvancedProgrammingNew.DataAccess.Contexts;



namespace AdvancedProgrammingNew.ConsoleApp
{
    internal class Program
{
    static void Main(string[] args)
    {
        // Creando un contexto para interacturar con la base de datos.
        ApplicationContext applicationContext = new ApplicationContext(Data Source = "AdvancedProgrammingDB.sqlite");

        // Verificar si la BD no existe
        if (!AppContext.Database.CanConnect())

            // Migrando base de datos. Este paso genera la BD con las tablas configuradas en su migracion.
            AppContext.Database.Migrate();
    }
    
}
}