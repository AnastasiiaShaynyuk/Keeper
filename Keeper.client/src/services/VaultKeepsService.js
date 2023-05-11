import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"
import { Keep } from "../models/Keep.js";



class VaultKeepsService {

  async getVaultKeeps(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}/keeps`)
    logger.log('getting vault keeps', res.data)
    AppState.vaultKeeps = res.data.map(k => new Keep(k))
  }

  async addKeepVault(vaultId, keepId) {
    const res = await api.post("api/vaultkeeps", {vaultId, keepId});
    logger.log('adding keep', res.data)
    AppState.activeKeep.kept++;
  }

  // async setActiveVaultKeep(vaultKeepId) {
  //   const res = await api.get(`api/keeps/${vaultKeepId}`);
  //   logger.log(res.data);
  // }


  async deleteVaultKeep(vaultKeepId) {
      logger.log(vaultKeepId)
      const res = await api.delete(`api/vaultkeeps/${vaultKeepId}`)
      logger.log("Deleting VaultKeep", res.data);
    // const VKIndex = AppState.vaultKeeps.findIndex(k => k.id == vaultKeepId)
    //   logger.log(VKIndex)
    //   if (vaultKeepIndex !== -1) {
    //     AppState.vaultKeeps.splice(VKIndex, 1);
    //   }
  }
}

export const vaultKeepsService = new VaultKeepsService()

