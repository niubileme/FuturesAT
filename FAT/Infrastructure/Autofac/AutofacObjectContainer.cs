﻿using Autofac;
using Infrastructure.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Autofac
{
    public class AutofacObjectContainer : IObjectContainer
    {
        public AutofacObjectContainer() : this(new ContainerBuilder())
        {
        }

        public AutofacObjectContainer(ContainerBuilder containerBuilder)
        {
            ContainerBuilder = containerBuilder;
        }

        public ContainerBuilder ContainerBuilder { get; }

        public IContainer Container { get; private set; }



        public void Build()
        {
            Container = ContainerBuilder.Build();
        }

        public IObjectContainer Register(Type serviceType, Type implementationType, LifeTime lifetime = LifeTime.Singleton)
        {
            var registrationBuilder = ContainerBuilder.RegisterType(implementationType).As(serviceType);
            switch (lifetime)
            {
                case LifeTime.Singleton:
                    registrationBuilder.SingleInstance();
                    break;
                case LifeTime.Scoped:
                    registrationBuilder.InstancePerLifetimeScope();
                    break;
                case LifeTime.Transient:
                    registrationBuilder.InstancePerDependency();
                    break;
            }
            return this;
        }

        public object Resolve(Type serviceType)
        {
            return Container.Resolve(serviceType);
        }
    }
}
