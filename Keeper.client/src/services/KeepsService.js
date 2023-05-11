import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"


class KeepsService {
  async getAllKeeps() {
    AppState.activeKeep = null
    const res = await api.get('api/keeps')
    AppState.keeps = res.data.map(k => new Keep(k))
  }

  async createKeep(keepData) {
    const res = await api.post('api/keeps', keepData)
    const newKeep = new Keep(res.data);
    AppState.keeps.unshift(newKeep)
    return newKeep
  }

  async setActiveKeep(keep) {
    const res = await api.get(`api/keeps/${keep.id}`);
    const creatorId = AppState.account.id
    if (keep.creatorId != creatorId) {
      keep.views++
    }
    AppState.activeKeep = keep
  }

  async deleteKeep(keepId) {
    const res = await api.delete(`api/keeps/${keepId}`)
    const keepIndex = AppState.keeps.findIndex((k) => k.id == keepId)
    if (keepIndex !== -1) {
      AppState.keeps.splice(keepIndex, 1)
    }
  }

  async getSavedKeeps(profileId) {
    const res = await api.get(`api/profiles/${profileId}/keeps`)
    AppState.myKeeps = res.data
  }
}

export const keepsService = new KeepsService()