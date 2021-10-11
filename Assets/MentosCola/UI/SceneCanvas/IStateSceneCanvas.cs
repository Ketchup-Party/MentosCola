namespace MentosCola {
    /// <summary>シーンの代わりをするキャンバス</summary>
    public interface IStateSceneCanvas {
        public void Deactivate();
        public void Activate();
    }
}
