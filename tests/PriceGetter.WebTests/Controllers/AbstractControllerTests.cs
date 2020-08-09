using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Routing;
using PriceGetter.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace PriceGetter.WebTests.Controllers
{
    public class AbstractControllerTests
    {
        [Fact]
        public void GetAllNonAbstractPublicClassFromControllersNamespace_Returns_NonEmptyCollection()
        {
            var controllers = GetAllNonAbstractPublicClassFromControllersNamespace();

            controllers.Should().NotBeEmpty();
        }

        [Theory]
        [MemberData(nameof(GetAllNonAbstractPublicClassFromControllersNamespace))]
        public void AllClassesFromNamespace_ShouldInheritFrom_AbstractController(Type type)
        {
            type.IsSubclassOf(typeof(AbstractController)).Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(GetAllSubclassesOfAbstractController))]
        public void AllSubclassesOfAbstractConttoller_ShouldBePublic(Type type)
        {
            type.IsPublic.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(GetAllSubclassesOfAbstractController))]
        public void AllControllersPublicMethods_Should_HaveHttpMethodDeclared(Type type)
        {
            type.IsPublic.Should().BeTrue();
            var methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);

        }

        [Theory]
        [MemberData(nameof(GetAllControllersPublicMethods))]
        public void EveryPublicMethod_Should_HaveHttpMethodAttribute(MethodInfo method)
        {
            bool hasHttpMethodAttribute = method.CustomAttributes
                .Any(x => x.AttributeType.IsSubclassOf(typeof(HttpMethodAttribute)));

            hasHttpMethodAttribute.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(GetAllSubclassesOfAbstractController))]
        public void EveryPublicMethod_Should_HaveHttpMethodAttribute2(Type type)
        {
            foreach (var method in type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public))
            {
                bool hasHttpMethodAttribute = method.CustomAttributes
                .Any(x => x.AttributeType.IsSubclassOf(typeof(HttpMethodAttribute)));

                hasHttpMethodAttribute.Should().BeTrue();
            }
        }

        [Fact]
        public void MethodReturningAllMethods_Should_NotReturnEmptyCollection()
        {
            var methods = GetAllControllersPublicMethods();

            methods.Should().NotBeEmpty();
        }

        [Fact]
        public void MethodReturningAllMethods_Should_NotReturnNull()
        {
            var methods = GetAllControllersPublicMethods();

            methods.Should().NotBeNull();
        }

        public static IEnumerable<object[]> GetAllNonAbstractPublicClassFromControllersNamespace()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(AbstractController));
            IEnumerable<Type> controllers = assembly.GetTypes()
                .Where(x => x != null)
                .Where(x => x.IsClass)
                .Where(x => x.IsPublic)
                .Where(x => x.IsAbstract == false)
                .Where(x => x.Namespace.StartsWith("PriceGetter.Web.Controllers"));

            return controllers.Select(x => new object[] { x });
        }

        public static IEnumerable<object[]> GetAllSubclassesOfAbstractController()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(AbstractController));
            IEnumerable<Type> controllers = assembly.GetTypes()
                .Where(x => x != null)
                .Where(x => x.IsSubclassOf(typeof(AbstractController)));

            return controllers.Select(x => new object[] { x });
        }

        public static IEnumerable<object[]> GetAllControllersPublicMethods()
        {
            List<MethodInfo> methods = new List<MethodInfo>();
            IEnumerable<Type> controllers = GetAllSubclassesOfAbstractController().Select(x => (Type)x.First()).ToList();

            foreach (var type in controllers)
            {
                var typeMethods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
                methods.AddRange(typeMethods);
            }

            return methods.Select(x => new object[] { x });
        }   
    }
}
