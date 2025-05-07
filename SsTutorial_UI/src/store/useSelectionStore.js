import { create } from 'zustand';

const useSelectionStore = create((set) => ({
  standard: '',
  subject: '',
  setStandard: (standard) => set({ standard }),
  setSubject: (subject) => set({ subject }),
}));

export default useSelectionStore;
