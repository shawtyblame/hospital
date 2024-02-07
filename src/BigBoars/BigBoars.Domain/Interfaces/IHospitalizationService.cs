using BigBoars.Domain.Dtos;

namespace BigBoars.Domain.Interfaces;
public interface IHospitalizationService
{
    public Task HospitalizeAsync(HospitalizationDto hospitalizationDto);
    public Task RejectByUserAsync(int patientId);
    public Task RejectAsync(int id);
}
