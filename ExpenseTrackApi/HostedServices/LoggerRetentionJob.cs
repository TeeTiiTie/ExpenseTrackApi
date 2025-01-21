﻿using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Quartz;
using Serilog;

namespace ExpenseTrackApi.HostedServices
{
    /// <summary>
    /// LoggerRetentionJob is a job to delete old log in database.
    /// Normally set for 90 days retention before delete old log.
    /// </summary>
    public class LoggerRetentionJob : IJob
    {
        // Connection String.
        private string _connectionString;

        // Priod of retention time in days.
        private int _retentionTime;

        private string _tableName;

        public LoggerRetentionJob(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _retentionTime = configuration.GetValue<int>("Serilog:WriteTo:2:Args:sinkOptionsSection:retainedPeriod", 90);
            _tableName = configuration.GetValue<string>("Serilog:WriteTo:2:Args:sinkOptionsSection:tableName", "[Logs]");
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    var retentionDatetime = DateTime.Now.AddDays(-1 * _retentionTime);
                    var sqlCommand = new SqlCommand($"DELETE FROM [EventLogging].@TableName WHERE [TimeStamp] < @RetentionTime;", connection);
                    sqlCommand.Parameters.Add("@RetentionTime", System.Data.SqlDbType.DateTime);
                    sqlCommand.Parameters["@RetentionTime"].Value = retentionDatetime;
                    sqlCommand.Parameters["@TableName"].Value = _tableName;

                    var returnRows = await sqlCommand.ExecuteNonQueryAsync();

                    Log.Verbose("RetentionTime : {retentionDatetime}", retentionDatetime);
                    Log.Information("{Services} Delete log out of retention completed [From={RetentionTime},Deleted={NumberOfRows}]", nameof(LoggerRetentionJob), retentionDatetime, returnRows);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "{Services} Delete log out of retention failed.", nameof(LoggerRetentionJob));
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }
    }
}