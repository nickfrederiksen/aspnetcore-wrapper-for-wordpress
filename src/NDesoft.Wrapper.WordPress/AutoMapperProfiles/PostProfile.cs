using AutoMapper;
using NDesoft.Wrapper.Models;
using NDesoft.Wrapper.WordPress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDesoft.Wrapper.WordPress.AutomapperSetup
{
public class PostProfile : Profile
{
	public PostProfile()
	{
		CreateMap<Post, PostModel>()
			.ForMember(dest => dest.Date, m => m.MapFrom(src => src.date_gmt))
			.ForMember(dest => dest.Modified, m => m.MapFrom(src => src.modified_gmt))
			.ForMember(dest => dest.Title, m => m.MapFrom(src => src.title.rendered))
			.ForMember(dest => dest.Content, m => m.MapFrom(src => src.content.rendered))
			.ForMember(dest => dest.Excerpt, m => m.MapFrom(src => src.excerpt))
			.ForMember(dest => dest.AuthorId, m => m.MapFrom(src => src.author))
			.ForMember(dest => dest.FeaturedMediaId, m => m.MapFrom(src => src.featured_media))
			.ForMember(dest => dest.IsSticky, m => m.MapFrom(src => src.sticky))
			.ForMember(dest => dest.CategoryIds, m => m.MapFrom(src => src.categories))
			.ForMember(dest => dest.TagIds, m => m.MapFrom(src => src.tags));
	}
}
}
