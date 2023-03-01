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
    private readonly string _departmentId = "633702dedf4f84aa0b630c14";
    private DepartmentModel _expectedDepartment;

    [SetUp]
    public void Setup()
    {
        _departmentRepositoryMock = new Mock<IDepartmentRepository>();
        _mapperMock = new Mock<IMapper>();
        _sut = new DepartmentService(_departmentRepositoryMock.Object, _mapperMock.Object);

        _expectedDepartment = new DepartmentModel
        {
            Id = _departmentId,
            DepartmentName = "IT"
        };
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

    [Test]
    public void WhenDepartmentIdIsValid_ThenIExpectTheRightDepartmentResponse()
    {
        _departmentRepositoryMock.Setup(mock => mock.GetDepartmentById(_departmentId)).ReturnsAsync(_expectedDepartment);

        var result = _sut.GetDepartmentById(_departmentId);

        Assert.That(() => result.Result, Is.EqualTo(_expectedDepartment));
    }
}
