using AutoMapper;
using FantasyFootball.Common.SqlContext;
using FantasyFootball.Common.Wrappers;

namespace FantasyFootball.Common.Mappers
{
    public static class WrapperToDatabase
    {
        static WrapperToDatabase()
        {
            Mapper.CreateMap<UserWrapper, User>();
            Mapper.CreateMap<UsersTeamWrapper, UsersTeam>();
            Mapper.CreateMap<RoleWrapper, Role>();
            Mapper.CreateMap<PlayerWrapper, Player>();
            Mapper.CreateMap<MatchWrapper, Match>();
            Mapper.CreateMap<MatchsActionWrapper, MatchsAction>();
            Mapper.CreateMap<ActionWrapper, Action>();
            Mapper.CreateMap<LeagueWrapper, League>();
        }

        public static User ToDatabaseUser(this UserWrapper entity)
        {
            return Mapper.Map<UserWrapper, User>(entity);
        }

        public static UsersTeam ToDatabaseUsersTeam(this UsersTeamWrapper entity)
        {
            return Mapper.Map<UsersTeamWrapper, UsersTeam>(entity);
        }

        public static Role ToDatabaseRole(this RoleWrapper entity)
        {
            return Mapper.Map<RoleWrapper, Role>(entity);
        }

        public static Player ToDatabasePlayer(this PlayerWrapper entity)
        {
            return Mapper.Map<PlayerWrapper, Player>(entity);
        }

        public static Match ToDatabaseMatch(this MatchWrapper entity)
        {
            return Mapper.Map<MatchWrapper, Match>(entity);
        }

        public static MatchsAction ToDatabaseMatchsAction(this MatchsActionWrapper entity)
        {
            return Mapper.Map<MatchsActionWrapper, MatchsAction>(entity);
        }

        public static Action ToDatabaseAction(this ActionWrapper entity)
        {
            return Mapper.Map<ActionWrapper, Action>(entity);
        }

        public static League ToDatabaseLeague(this LeagueWrapper entity)
        {
            return Mapper.Map<LeagueWrapper, League>(entity);
        }
    }
}
