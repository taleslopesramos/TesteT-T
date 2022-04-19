using DAL.Enums;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class DbLogger<T> : ILogger<T>
    {
        private readonly AppDbContext _context;

        public DbLogger(AppDbContext context)
        {
            _context = context;
        }

        public void LogAdd(T entity)
        {
            if (entity == null) return;

            Log log = new Log()
            {
                EntityName = entity.GetType().Name,
                Type = LogType.Add,
                newProperties = JsonConvert.SerializeObject(entity, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    })
            };

            _context.Add(log);
            _context.SaveChanges();
        }

        public void LogRemove(T entity)
        {
            if (entity == null) return;

            Log log = new Log()
            {
                EntityName = entity.GetType().Name,
                Type = LogType.Remove,
                oldProperties = JsonConvert.SerializeObject(entity, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    })
            };

            _context.Add(log);
            _context.SaveChanges();
        }

        public void LogUpdate(T entity)
        {
            if (entity == null) return;

            EntityEntry? changeInfo = _context.ChangeTracker
                .Entries()
                .Where(t =>
                    t.State == EntityState.Modified)
                .SingleOrDefault();

            if (changeInfo == null) return;

            object? oldValue = changeInfo.GetDatabaseValues().ToObject();

            Log log = new Log()
            {
                EntityName = entity.GetType().Name,
                Type = LogType.Remove,
                oldProperties = JsonConvert.SerializeObject(oldValue, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    }),
                newProperties = JsonConvert.SerializeObject(entity, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    })
            };

            _context.Add(log);
            _context.SaveChanges();
        }
        public void LogError(T entity, string message)
        {
            if (entity == null) return;

            Log log = new Log()
            {
                EntityName = entity.GetType().Name,
                Type = LogType.Error,
                oldProperties = JsonConvert.SerializeObject(entity, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    }),
                Exception = message
            };

            _context.Add(log);
            _context.SaveChanges();
        }
    }
}
