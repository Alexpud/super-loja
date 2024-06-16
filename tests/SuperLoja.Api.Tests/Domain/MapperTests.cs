using AutoMapper;
using SuperLoja.Api.Domain.Profiles;

namespace SuperLoja.Api.Tests.Domain;

public class MapperTests
{
    [Fact(DisplayName = "Profile do AutoMapper MappingProfile deve ser valido")]
    public void MappingProfile_DeveSerValido()
    {   
        // Arrange & Act
        var configuration = new MapperConfiguration(p => p.AddProfile<MappingProfile>());

        // Assert
        configuration.AssertConfigurationIsValid();
    }
}