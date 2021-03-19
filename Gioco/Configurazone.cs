using ADORepository;
using Gioco.Core.Interfacce;
using Gioco.Service;
using Microsoft.Extensions.DependencyInjection;
using MockRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gioco
{
    public class Configurazone
    {
        public static ServiceProvider Configurazione()
        {
            return new ServiceCollection()
                //qui aggiungo i servizi creati da me
                .AddScoped<EroeService>()
                .AddScoped<GiocatoreService>()
                .AddScoped<ArmaService>()
                .AddScoped<ClasseService>()
                .AddScoped<LivelloService>()
                .AddScoped<MostroService>()

                //Comandi per Mock
                //.AddTransient<IEroeRepository, MockEroeRepository>()
                //.AddTransient<IGiocatoreRepository, MockGiocatoreRepository>()
                //.AddTransient<IArmaRepository, MockArmaRepository>()
                //.AddTransient<IMostroRepository, MockMostroRepository>()
                //.AddTransient<IClasseRepository, MockClasseRepository>()
                //.AddTransient<ILivelloRepository, MockLivelloRepository>()


                //Comandi per ADO
                .AddTransient<IEroeRepository, AdoEroeRepository>()
                .AddTransient<IGiocatoreRepository, AdoGiocatoreRepository>()
                .AddTransient<IArmaRepository, AdoArmaRepository>()
                .AddTransient<IMostroRepository, AdoMostroRepository>()
                .AddTransient<IClasseRepository, AdoClasseRepository>()
                .AddTransient<ILivelloRepository, AdoLivelloRepository>()

                .BuildServiceProvider();
        }
    }
}
