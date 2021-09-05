using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using FarmApp.Infra.Data.Context;
using FarmApp.Infra.Data.Repository;
using FarmApp.Service;
using FarmApp.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FarmApp.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Db_FarmAppContext>(options =>
            {
                var connection = Configuration["ConnectionStrings:Default"];

                options.UseMySql(connection, ServerVersion.AutoDetect(connection));
            });

            services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient(typeof(ILoginService), typeof(LoginService));
            services.AddTransient(typeof(IClienteRepository), typeof(ClienteRepository));
            services.AddTransient(typeof(IClienteService), typeof(ClienteService));
            services.AddTransient(typeof(IEnderecoRepository), typeof(EnderecoRepository));
            services.AddTransient(typeof(IEnderecoService), typeof(EnderecoService));
            services.AddTransient(typeof(IUfRepository), typeof(UfRepository));
            services.AddTransient(typeof(IUfService), typeof(UfService));
            services.AddTransient(typeof(ICidadeRepository), typeof(CidadeRepository));
            services.AddTransient(typeof(ICidadeService), typeof(CidadeService));
            services.AddTransient(typeof(IBairroRepository), typeof(BairroRepository));
            services.AddTransient(typeof(IBairroService), typeof(BairroService));
            services.AddTransient(typeof(ICepRepository), typeof(CepRepository));
            services.AddTransient(typeof(ICepService), typeof(CepService));
            services.AddTransient(typeof(IContaPessoalRepository), typeof(ContaPessoalRepository));
            services.AddTransient(typeof(IContaPessoalService), typeof(ContaPessoalService));
            services.AddTransient(typeof(IContaRepository), typeof(ContaRepository));
            services.AddTransient(typeof(IContaService), typeof(ContaService));
            services.AddTransient(typeof(IEnderecoContaPessoalRepository), typeof(EnderecoContaPessoalRepository));
            services.AddTransient(typeof(IEnderecoContaPessoalService), typeof(EnderecoContaPessoalService));
            services.AddTransient(typeof(ITipoEnderecoRepository), typeof(TipoEnderecoRepository));
            services.AddTransient(typeof(ITipoEnderecoService), typeof(TipoEnderecoService));
            services.AddTransient(typeof(IMailService), typeof(MailService));
            services.AddTransient(typeof(IConsentimentoService), typeof(ConsentimentoService));
            services.AddTransient(typeof(IConsentimentoRepository), typeof(ConsentimentoRepository));



            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

           
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FarmApp API V1");
            });


            app.UseHttpsRedirection();

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
