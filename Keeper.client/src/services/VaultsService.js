import { logger } from "../utils/Logger"
import { api } from "./AxiosService"
import { AppState } from "../AppState";
import { Vault } from "../models/Vault";



class VaultsService {
  async createVault(vaultData) {
    const res = await api.post('api/vaults', vaultData)
    logger.log('creating vault', res.data)
    AppState.vaults.push(new Vault(res.data));
    return res.data;
  }

  async getVaultById(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}`)
    logger.log('getting my vault', res.data)
    AppState.vault = new Vault(res.data)
  }

  async deleteVault(vaultId) {
    const res = await api.delete(`api/vaults/${vaultId}`)
    logger.log("deleting my vault", res.data);
  }
}

export const vaultsService = new VaultsService()




//   async getMyVaults(){
//     const res = await api.get('account/vaults')
//     AppState.myVaults = res.data
//   }

//   async createVault(vaultData){
//     if(vaultData.isPrivate == null){
//       vaultData.isPrivate = false
//     }
//     const res = await api.post('api/vaults', vaultData)
//     AppState.myVaults.unshift(res.data)
//   }

//   async getVault(vaultId){
//     const res = await api.get(`api/vaults/${vaultId}`)
//     AppState.vault = res.data
//   }

//   async getKeepsInVault(vaultId){
//     const res = await api.get(`api/vaults/${vaultId}/keeps`)
//     AppState.keeps = res.data
//     logger.log(AppState.keeps)
//   }

//   async deleteVault(vaultId){
//     const res = await api.delete('api/vaults/' + vaultId)
//   }

//   async updateVault(vaultData){
//     const res = await api.put(`api/vaults/${vaultData.id}`, vaultData)
//     AppState.vault = res.data
//   }
// }

