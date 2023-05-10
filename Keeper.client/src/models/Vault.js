import { Profile } from "./Account";

export class Vault {
  constructor(data) {
    this.id = data.id;
    this.name = data.name;
    this.description = data.description;
    this.img = data.img;
    this.isPrivate = data.isPrivate;
    this.creatorId = data.creatorId;
    this.creator = new Profile(data.creator);
    this.createdAt = new Date(data.createdAt);
    this.updatedAt = new Date(data.updatedAt);
  }
}

