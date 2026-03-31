using KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery;
using KuyumHesap.Persistence.Common.Context;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Persistence.Common.Concrete.SqlFunctions
{
    public class SettingTableCheckService : ISettingTableCheckService
    {
        private readonly AppDbContext _context;

        public SettingTableCheckService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(bool tableCreated, string message)> EnsureSettingsTableExistsAsync(CancellationToken ct)
        {
            var tableCreated = false;
            var message = string.Empty;

            // 1. Tablo var mı kontrol et
            var checkTableSql = "SELECT COUNT(*) FROM sys.tables WHERE name = 'Settings'";
            var tableExists = false;

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = checkTableSql;
                if (command.Connection.State != System.Data.ConnectionState.Open) await command.Connection.OpenAsync(ct);
                var result = await command.ExecuteScalarAsync(ct);
                tableExists = (int)result > 0;
            }

            if (!tableExists)
            {
                // 2. Tabloyu oluştur
                var createTableSql = @"
                    CREATE TABLE [dbo].[Settings] (
                        [Id] [int] IDENTITY(1,1) NOT NULL,
                        [Key] [nvarchar](100) NOT NULL,
                        [Value] [nvarchar](max) NULL,
                        [Description] [nvarchar](max) NULL,
                        [IsDeleted] [bit] NOT NULL DEFAULT 0,
                        [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
                        [ModifyDate] [datetime] NULL,
                        [CreatedByUserId] [int] NOT NULL,
                        [UpdatedByUserId] [int] NULL,
                        CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED ([Id] ASC)
                    );
                    CREATE UNIQUE INDEX [IX_Settings_Key] ON [dbo].[Settings] ([Key]) WHERE [IsDeleted] = 0;
                ";

                await _context.Database.ExecuteSqlRawAsync(createTableSql, ct);
                tableCreated = true;
                message = "Settings tablosu başarıyla oluşturuldu.";
            }

            // 3. Veri var mı kontrol et (Seed)
            var countSql = "SELECT COUNT(*) FROM Settings WHERE IsDeleted = 0";
            var hasData = false;
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = countSql;
                if (command.Connection.State != System.Data.ConnectionState.Open) await command.Connection.OpenAsync(ct);
                var count = await command.ExecuteScalarAsync(ct);
                hasData = (int)count > 0;
            }

            if (!hasData)
            {
                var seedSql = @"
                    INSERT INTO Settings ([Key], [Description], [CreatedByUserId], [CreatedDate]) VALUES 
                    ('CashAccountTypeId', 'Nakit tahsilat/ödeme işlemlerinde kullanılacak kasa hesabının AccountType ID''si', 1, GETDATE()),
                    ('PosAccountTypeId', 'POS cihazı üzerinden yapılan tahsilat/ödeme hesabının AccountType ID''si', 1, GETDATE()),
                    ('BankAccountTypeId', 'Banka havalesi/EFT işlemlerinde kullanılacak hesabın AccountType ID''si', 1, GETDATE()),
                    ('SalesCurrencyId', 'Satış işlemlerinde varsayılan olarak seçilecek para biriminin Currency ID''si', 1, GETDATE()),
                    ('CashierAccountTypeId', 'Satış ekranında tezgahtar seçiminde listelenen hesapların AccountType ID''si', 1, GETDATE()),
                    ('CustomerAccountTypeId', 'Satış ekranında müşteri listesinde gösterilecek hesapların AccountType ID''si', 1, GETDATE()),
                    ('DefaultCustomerAccountId', 'Satış ekranı açıldığında varsayılan olarak seçili gelecek müşteri Account ID''si', 1, GETDATE()),
                    ('DefaultCashAccountId', 'Nakit tahsilat/ödeme işlemlerinde varsayılan kasa hesabı', 1, GETDATE()),
                    ('DefaultDiscountAccountId', 'İskonto işlemlerinde borçlandırılacak hesap', 1, GETDATE());
                ";
                await _context.Database.ExecuteSqlRawAsync(seedSql, ct);
                if (!tableCreated) message = "Settings tablosu seed verileriyle dolduruldu.";
            }

            return (tableCreated, message);
        }
    }
}
