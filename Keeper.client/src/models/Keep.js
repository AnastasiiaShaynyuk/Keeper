import { Profile } from "./Account.js"


export class Keep {
  constructor(data) {
    this.id = data.id
    this.name = data.name
    this.description = data.description
    this.img = data.img
    this.views = data.views
    this.kept = data.kept
    this.creatorId = data.creatorId
    this.vaultKeepId = data.vaultKeepId
    this.creator = new Profile(data.creator)
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
  }
}
