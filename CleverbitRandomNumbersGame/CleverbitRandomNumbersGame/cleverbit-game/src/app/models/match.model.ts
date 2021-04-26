import { PlayerMatch } from "./player-match.model";

export class Match {
  id: number;
  startDateTime: Date;
  endDateTime: Date;
  playerMatches: Array<PlayerMatch>;
}
