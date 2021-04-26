import { User } from "./user.model";

export class PlayerMatch {
  id: number;
  player: User;
  number: number;
  playDate: Date;
}
