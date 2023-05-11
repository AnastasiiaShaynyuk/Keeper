import { AppState } from "../AppState.js"
import { Profile } from "../models/Account.js"
import { Keep } from "../models/Keep.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class ProfilesService {
  async getProfileById(profileId) {
    const res = await api.get("api/profiles/" + profileId);
    // logger.log('getting profile', res.data)
    AppState.profile = new Profile(res.data);
  }

  async getKeepsByProfileId(profileId) {
    const res = await api.get(`api/profiles/${profileId}/keeps`);
    // logger.log("Keeps by profile id", res.data);
    AppState.keeps = res.data.map((k) => new Keep(k));
  }

  async getVaultsByProfileId(profileId) {
    const res = await api.get(`api/profiles/${profileId}/vaults`);
    logger.log("Vaults by profile", res.data)
    AppState.vaults = res.data.map((v) => new Vault(v));
  }

}

export const profilesService = new ProfilesService()