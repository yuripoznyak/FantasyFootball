using FantasyFootball.Common.Dto;
using FantasyFootball.Common.SqlContext;
using AutoMapper;
using FantasyFootball.Common.Wrappers;

namespace FantasyFootball.Common.Mappers
{
    public static class DatabaseToWrapper
    {
        static DatabaseToWrapper()
        {
            Mapper.CreateMap<User, UserWrapper>();
            Mapper.CreateMap<UsersTeam, UsersTeamWrapper>();
            Mapper.CreateMap<Role, RoleWrapper>();
            Mapper.CreateMap<Player, PlayerWrapper>();
            Mapper.CreateMap<Match, MatchWrapper>();
            Mapper.CreateMap<MatchsAction, MatchsActionWrapper>();
            Mapper.CreateMap<Action, ActionWrapper>();
        }

        public static UserWrapper ToUserWrapper(this User entity)
        {
            return Mapper.Map<User, UserWrapper>(entity);
        }

        public static UsersTeamWrapper ToUsersTeamWrapper(this UsersTeam entity)
        {
            return Mapper.Map<UsersTeam, UsersTeamWrapper>(entity);
        }

        public static RoleWrapper ToRoleWrapper(this Role entity)
        {
            return Mapper.Map<Role, RoleWrapper>(entity);
        }

        public static PlayerWrapper ToPlayerWrapper(this Player entity)
        {
            return Mapper.Map<Player, PlayerWrapper>(entity);
        }

        public static MatchWrapper ToMatchWrapper(this Match entity)
        {
            return Mapper.Map<Match, MatchWrapper>(entity);
        }

        public static MatchsActionWrapper ToMatchsActionWrapper(this MatchsAction entity)
        {
            return Mapper.Map<MatchsAction, MatchsActionWrapper>(entity);
        }

        public static ActionWrapper ToActionWrapper(this Action entity)
        {
            return Mapper.Map<Action, ActionWrapper>(entity);
        }

        public static LeagueWrapper ToLeagueWrapper(this League entity)
        {
            return Mapper.Map<League, LeagueWrapper>(entity);
        }
    }
}
