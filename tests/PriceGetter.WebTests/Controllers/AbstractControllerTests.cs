using FluentAssertions;
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
    }
}
