namespace KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery
{
    public interface ISettingTableCheckService
    {
        /// <summary>
        /// Check if Settings table exists, create it if missing, and seed initial data.
        /// </summary>
        /// <returns>True if the table was just created.</returns>
        Task<(bool tableCreated, string message)> EnsureSettingsTableExistsAsync(CancellationToken ct);
    }
}
