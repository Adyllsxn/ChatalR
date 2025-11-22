export const headerStyles = {
  // Header principal
  header: "fixed top-0 left-0 right-0 z-50 transition-all duration-500 bg-transparent backdrop-blur-md",
  scrolled: "bg-white/10 backdrop-blur-xl shadow-2xl shadow-black/10 border-b border-white/10",
  
  // Container
  container: "max-w-7xl mx-auto px-6 lg:px-8",
  
  // Nav
  nav: "flex items-center justify-between h-20",
  
  // Logo - MESMO ESTILO PARA AMBOS
  logoContainer: "z-50",
  logo: "relative group",
  logoText: "text-2xl lg:text-3xl font-black bg-gradient-to-r from-[#D9782C] to-[#f59e0b] bg-clip-text text-transparent", // MESMO TAMANHO
  logoUnderline: "absolute -bottom-2 left-0 w-0 h-1 bg-gradient-to-r from-[#D9782C] to-[#f59e0b] group-hover:w-full transition-all duration-500 rounded-full",
  
  // Desktop Menu
  desktopMenu: "hidden lg:flex items-center space-x-8",
  menuItem: "relative text-white/90 hover:text-white font-medium transition-colors duration-300 py-2 group",
  menuItemActive: "text-white font-semibold",
  menuUnderline: "absolute -bottom-1 left-0 w-0 h-0.5 bg-gradient-to-r from-[#D9782C] to-[#f59e0b] group-hover:w-full transition-all duration-500 rounded-full",
  
  // CTA Button
  ctaButton: "px-6 py-3 bg-gradient-to-r from-[#D9782C] to-[#f59e0b] text-white font-semibold rounded-2xl hover:shadow-2xl hover:shadow-orange-500/30 transition-all duration-500 flex items-center group",
  
  // Mobile Menu Button
  mobileButton: "lg:hidden relative z-50 p-3 rounded-2xl bg-white/10 backdrop-blur-md border border-white/20",
  hamburger: "w-6 h-6 relative flex flex-col justify-between",
  bar: "w-6 h-0.5 bg-white rounded-full transition-all duration-500 transform-gpu",
  barOpen: (index: number) => {
    const styles = {
      0: "rotate-45 translate-y-2.5 bg-gradient-to-r from-[#D9782C] to-[#f59e0b]",
      1: "opacity-0",
      2: "-rotate-45 -translate-y-2.5 bg-gradient-to-r from-[#D9782C] to-[#f59e0b]"
    };
    return styles[index as keyof typeof styles] || "";
  },
  
  // Mobile Menu Overlay
  mobileOverlay: "fixed inset-0 z-40 lg:hidden bg-black/80 backdrop-blur-sm",
  mobileMenu: "fixed top-0 left-0 right-0 bg-black border-b border-white/10 shadow-2xl",
  mobileHeader: "flex items-center justify-between p-6 border-b border-white/10 bg-black h-20", // MESMA ALTURA DO HEADER PRINCIPAL
  closeButton: "p-2 text-white/70 hover:text-white transition-colors duration-300 hover:bg-white/10 rounded-lg",
  
  // Mobile Content
  mobileContent: "p-6 space-y-3 bg-black max-h-[80vh] overflow-y-auto",
  mobileItem: "flex items-center justify-between p-4 text-white hover:bg-white/5 rounded-xl transition-all duration-300 border border-white/5 hover:border-white/20 group",
  mobileItemContent: "flex flex-col",
  mobileItemText: "text-lg font-semibold text-white",
  mobileItemSubtitle: "text-sm text-gray-400 mt-1",
  mobileCtaContainer: "pt-6 border-t border-white/10 mt-6",
  mobileCta: "w-full px-6 py-4 bg-gradient-to-r from-[#D9782C] to-[#f59e0b] text-white font-semibold rounded-xl hover:shadow-2xl hover:shadow-orange-500/30 transition-all duration-500 flex items-center justify-center group"
};