using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace CentricExpress.Business.Events
{
    public static class DomainEvents
    {
        private static IServiceProvider serviceProvider;

        public static void UseDomainEvents(this IServiceProvider serviceProvider)
        {
            DomainEvents.serviceProvider = serviceProvider;
        }

        [ThreadStatic] private static List<Delegate> actions;

        /// <summary>
        /// Clears callbacks passed to Register on the current thread.
        /// </summary>
        public static void ClearCallbacks()
        {
            actions = null;
        }
        
        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (actions == null)
            {
                actions = new List<Delegate>();
            }
            
            actions.Add(callback);
        }

        public static void Raise<T>(T domainEvent) where T : IDomainEvent
        {
            ExecuteRegisteredHandlers(domainEvent);
            ExecuteRegisteredActions(domainEvent);
        }

        private static void ExecuteRegisteredActions<T>(T domainEvent) where T : IDomainEvent
        {
            if (actions == null)
            {
                return;
            }

            foreach (var @delegate in actions)
            {
                if (@delegate is Action<T> action)
                    action(domainEvent);
                else
                    return;
            }
        }

        private static void ExecuteRegisteredHandlers<T>(T domainEvent) where T : IDomainEvent
        {
            if (serviceProvider == null)
            {
                return;
            }
            
            var domainEventHandlers = serviceProvider.GetServices<IDomainEventHandler<T>>();

            foreach (var domainEventHandler in domainEventHandlers)
            {
                domainEventHandler.Handle(domainEvent);
            }
        }

        public interface IDomainEventHandler<T>
        {
            void Handle(IDomainEvent domainEvent);
        }

        public interface IDomainEvent
        {
        }
    }
}