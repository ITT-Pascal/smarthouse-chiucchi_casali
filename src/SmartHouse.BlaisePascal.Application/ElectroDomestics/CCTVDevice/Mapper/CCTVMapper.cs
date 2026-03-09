using SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Dto;
using SmartHouse.BlaisePascal.Application.ElectroDomestics.Shared.Mapper;
using SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTVDevice;

namespace SmartHouse.BlaisePascal.Application.ElectroDomestics.CCTVDevice.Mapper
{
    public class CCTVMapper
    {
        public static CCTVDto ToDto(CCTV cctv)
        {
            return new CCTVDto
            {
                Id = cctv.Id,
                Name = cctv.Name._name,
                Status = DeviceStatusMapper.ToDto(cctv.Status),
                Pin = cctv.Pin._pin,
                LockStatus = LockStatusMapper.ToDto(cctv.LockStatus),
                Mode = CCTVModeMapper.ToDto(cctv.Mode),
                FOV = cctv.FOV._fov,
                CreationTime_UTC = cctv.CreationTime_UTC,
                LastModification_UTC = cctv.LastModification_UTC
            };
        }

        public static CCTV ToDomain(CCTVDto dto)
        {
            return new CCTV(
                dto.Id,
                dto.Name,
                DeviceStatusMapper.ToDomain(dto.Status),
                dto.Pin,
                LockStatusMapper.ToDomain(dto.LockStatus),
                CCTVModeMapper.ToDomain(dto.Mode),
                dto.FOV,
                dto.CreationTime_UTC,
                dto.LastModification_UTC
                );
        }
    }
}
