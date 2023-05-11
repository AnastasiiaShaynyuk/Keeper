import { AppState } from "../AppState.js"
import { Profile } from "../models/Account.js"
import { Keep } from "../models/Keep.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class ProfilesService {
  async getProfileById(profileId) {
    const res = await api.get("api/profiles/" + profileId);
    AppState.profile = new Profile(res.data);
  }

  async getKeepsByProfileId(profileId) {
    const res = await api.get(`api/profiles/${profileId}/keeps`);
    AppState.keeps = res.data.map((k) => new Keep(k));
  }

  async getVaultsByProfileId(profileId) {
    const res = await api.get(`api/profiles/${profileId}/vaults`);
    AppState.vaults = res.data.map((v) => new Vault(v));
  }

}

export const profilesService = new ProfilesService()