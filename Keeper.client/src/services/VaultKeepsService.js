import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"
import { Keep } from "../models/Keep.js";



class VaultKeepsService {

  async getVaultKeeps(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}/keeps`)
    logger.log('getting vault keeps', res.data)
    AppState.keeps = res.data.map(k => new Keep(k))
  }

  async addKeepVault(vaultId, keepId) {
    const res = await api.post("api/vaultkeeps", {vaultId, keepId});
    logger.log('adding keep', res.data)
    
  }
}

export const vaultKeepsService = new VaultKeepsService()

