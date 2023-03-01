using Microsoft.AspNetCore.Http;

namespace UserManagement.Tests.Unit.Department;

[TestFixture]
public class GivenIHaveAGetDepartmentRequest
{
    private DepartmentService _sut;
    private Mock<IDepartmentRepository> _departmentRepositoryMock;
    private Mock<IMapper> _mapperMock;
    private readonly string _departmentIdNull = null;
    private readonly string _departmentIdEmpty = "";

    [SetUp]
    public void Setup()
    {
        _departmentRepositoryMock = new Mock<IDepartmentRepository>();
        _mapperMock = new Mock<IMapper>();
        _sut = new DepartmentService(_departmentRepositoryMock.Object, _mapperMock.Object);
    }

    [Test]
    public void WhenDepartmentIdIsNull_ThenIGetABadRequestResponse()
    {
        _departmentRepositoryMock.Setup(mock => mock.GetDepartmentById(_departmentIdNull));

        var result = _sut.GetDepartmentById(_departmentIdNull);

        Assert.That(() => result, Throws.Exception.TypeOf<BadHttpRequestException>());
    }

    [Test]
    public void WhenDepartmentIdIsIncorrect_ThenIGetAKeyNotFoundResponse()
    {
        _departmentRepositoryMock.Setup(mock => mock.GetDepartmentById(_departmentIdEmpty));

        var result = _sut.GetDepartmentById(_departmentIdEmpty);

        Assert.That(() => result, Throws.Exception.TypeOf<KeyNotFoundException>());
    }
}
