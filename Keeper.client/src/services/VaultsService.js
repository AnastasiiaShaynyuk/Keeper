import { logger } from "../utils/Logger"
import { api } from "./AxiosService"
import { AppState } from "../AppState";
import { Vault } from "../models/Vault";



class VaultsService {
  async createVault(vaultData, userId) {
    const res = await api.post('api/vaults', vaultData)
    AppState.vaults.push(new Vault(res.data));
    if (res.data.creatorId == userId) {
      AppState.myVaults.push(new Vault(res.data));
    }
  }

  async getVaultById(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}`)
    AppState.vault = new Vault(res.data)
  }

  async deleteVault(vaultId) {
    const res = await api.delete(`api/vaults/${vaultId}`)
  }
}

export const vaultsService = new VaultsService()
