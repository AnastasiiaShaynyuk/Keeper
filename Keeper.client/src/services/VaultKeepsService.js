import { AppState } from "../AppState";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";
import { Keep } from "../models/Keep.js";

class VaultKeepsService {
  async getVaultKeeps(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}/keeps`);
    AppState.vaultKeeps = res.data.map((k) => new Keep(k));
  }

  async addKeepVault(vaultId, keepId) {
    const res = await api.post("api/vaultkeeps", { vaultId, keepId });
    logger.log("adding keep", res.data);
    AppState.activeKeep.kept++;
  }

  async deleteVaultKeep(vaultKeepId) {
    const res = await api.delete(`api/vaultkeeps/${vaultKeepId}`);
    const VKIndex = AppState.vaultKeeps.findIndex((k) => k.id == vaultKeepId);
    AppState.vaultKeeps.splice(VKIndex, 1);
  }
}

export const vaultKeepsService = new VaultKeepsService();
