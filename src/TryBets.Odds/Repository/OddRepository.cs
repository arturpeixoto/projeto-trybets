using TryBets.Odds.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Globalization;

namespace TryBets.Odds.Repository;

public class OddRepository : IOddRepository
{
    protected readonly ITryBetsContext _context;
    public OddRepository(ITryBetsContext context)
    {
        _context = context;
    }

    public Match Patch(int MatchId, int TeamId, string BetValue)
    {
        string BetValueConverted = BetValue.Replace(',', '.');
        decimal BetValueDecimal = decimal.Parse(BetValueConverted, CultureInfo.InvariantCulture);
        Match findedMatch = _context.Matches.FirstOrDefault(m => m.MatchId == MatchId)!;
        if (findedMatch == null) throw new Exception("Match not founded");

        Team findedTeam = _context.Teams.FirstOrDefault(t => t.TeamId == TeamId)!;
        if (findedTeam == null) throw new Exception("Team not founded");

        if (findedMatch.MatchTeamAId != findedTeam.TeamId && findedMatch.MatchTeamBId != findedTeam.TeamId ) throw new Exception("Team is not in this match");

        if (findedMatch.MatchTeamAId == findedTeam.TeamId) findedMatch.MatchTeamAValue += BetValueDecimal;
        else findedMatch.MatchTeamBValue += BetValueDecimal;
        _context.Matches.Update(findedMatch);
        _context.SaveChanges();

        return findedMatch;
    }
}