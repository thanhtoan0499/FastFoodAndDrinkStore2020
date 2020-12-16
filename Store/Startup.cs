using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using AutoMapper;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.Interfaces;
using Store.Services;
namespace Store
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
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IUnitOfWorkProduct, UnitOfWorkProduct>();
            services.AddScoped<IUnitOfWorkStaff, UnitOfWorkStaff>();
            services.AddScoped<IUnitOfWorkCustomer, UnitOfWorkCustomer>();
            services.AddScoped<IUnitOfWorkSupplier, UnitOfWorkSupplier>();
            services.AddScoped<IUnitOfWorkPromotion, UnitOfWorkPromotion>();
            services.AddScoped<IUnitOfWorkInvoice, UnitOfWorkInvoice>();
            services.AddScoped<IUnitOfWorkDetailInvoice, UnitOfWorkDetailInvoice>();
            services.AddScoped<IUnitOfWorkReceipt, UnitOfWorkReceipt>();
            services.AddScoped<IUnitOfWorkDetailReceipt, UnitOfWorkDetailReceipt>();
            services.AddScoped<IUnitOfWorkAccount, UnitOfWorkAccount>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStaffService, StaffService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IPromotionService, PromotionService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IReceiptService, ReceiptService>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IProductIndexVmService, ProductIndexVmService>();
            services.AddScoped<IStaffIndexVmService, StaffIndexVmService>();
            services.AddScoped<ICustomerIndexVmService, CustomerIndexVmService>();
            services.AddScoped<ISupplierIndexVmService, SupplierIndexVmService>();
            services.AddScoped<IPromotionIndexVmService, PromotionIndexVmService>();
            services.AddScoped<IInvoiceIndexVmService, InvoiceIndexVmService>();
            services.AddScoped<IDetailInvoiceIndexVmService, DetailInvoiceIndexVmService>();
            services.AddScoped<IReceiptIndexVmService, ReceiptIndexVmService>();
            services.AddScoped<IDetailReceiptIndexVmService, DetailReceiptIndexVmService>();
            services.AddScoped<IAccountIndexVmService, AccountIndexVmService>();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddDbContext<ProductContext>(options => options.UseSqlite("Data source= .\\Database\\Product.db"));
            services.AddDbContext<StaffContext>(options => options.UseSqlite("Data source=.\\Database\\Staff.db"));
            services.AddDbContext<CustomerContext>(options => options.UseSqlite("Data source=.\\Database\\Customer.db"));
            services.AddDbContext<SupplierContext>(options => options.UseSqlite("Data source=.\\Database\\Supplier.db"));
            services.AddDbContext<PromotionContext>(options => options.UseSqlite("Data source=.\\Database\\Promotion.db"));
            services.AddDbContext<InvoiceContext>(options => options.UseSqlite("Data source=.\\Database\\Invoice.db"));
            services.AddDbContext<DetailInvoiceContext>(options => options.UseSqlite("Data source=.\\Database\\DetailInvoice.db"));
            services.AddDbContext<ReceiptContext>(options => options.UseSqlite("Data source=.\\Database\\Receipt.db"));
            services.AddDbContext<DetailReceiptContext>(options => options.UseSqlite("Data source=.\\Database\\DetailReceipt.db"));
            services.AddDbContext<AccountContext>(options => options.UseSqlite("Data source=.\\Database\\Account.db"));

            services.AddRazorPages();
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
